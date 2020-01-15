using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Net.Sockets;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace client
{

	public partial class Form1 : Form
	{
		List<Author> authors = new List<Author>();
		List<int> selectArray = new List<int>();

		public string SendData(string message, string addType, string RWType)
		{
			int port = 8005; // порт сервера
			string address = "127.0.0.1"; // адрес сервера
			string addFlag = "";
			string RWFlag = "";
			try
			{
				IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

				Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				// подключаемся к удаленному хосту
				socket.Connect(ipPoint);


				if (addType == "Author")
				{
					addFlag = "0";
				}

				if (addType == "Book")
				{
					addFlag = "1";
				}

				message = RWType + addFlag + message;
				byte[] data = Encoding.Unicode.GetBytes(message);
				socket.Send(data);

				// получаем ответ
				data = new byte[256]; // буфер для ответа
				StringBuilder builder = new StringBuilder();
				int bytes = 0; // количество полученных байт

				do
				{
					bytes = socket.Receive(data, data.Length, 0);
					builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
				}
				while (socket.Available > 0);


				// закрываем сокет
				socket.Shutdown(SocketShutdown.Both);
				socket.Close();

				return builder.ToString();
			}
			catch (Exception ex)
			{
				return "error: " + ex.Message;
			}
		}

		public Form1()
		{
			InitializeComponent();
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			
		}




		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			comboBox2.Items.Add("Detective");
			comboBox2.Items.Add("Horror");
			comboBox2.Items.Add("Romance");
			comboBox2.Items.Add("Manga");
			comboBox2.Items.Add("Mystic");
			comboBox2.Items.Add("Adventure");
			comboBox2.Items.Add("Fairy tale");
			comboBox2.Items.Add("Biography");

			var column1 = new DataGridViewColumn();
			column1.HeaderText = "Name"; //текст в шапке
			column1.Width = 100; //ширина колонки
			column1.ReadOnly = true; //значение в этой колонке нельзя править
			column1.Name = "name"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
			//column1.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
			column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

			var column2 = new DataGridViewColumn();
			column2.HeaderText = "Author";
			column2.Name = "author";
			column2.CellTemplate = new DataGridViewTextBoxCell();

			var column3 = new DataGridViewColumn();
			column3.HeaderText = "Genre";
			column3.Name = "genre";
			column3.CellTemplate = new DataGridViewTextBoxCell();

			var column4 = new DataGridViewColumn();
			column4.HeaderText = "Publication date";
			column4.Name = "publicationDate";
			column4.CellTemplate = new DataGridViewTextBoxCell();

			dataGridView1.Columns.Add(column1);
			dataGridView1.Columns.Add(column2);
			dataGridView1.Columns.Add(column3);
			dataGridView1.Columns.Add(column4);

			//Добавляем строку, указывая значения колонок поочереди слева направо
			//dataGridView1.Rows.Add("name", "author", "gen", "123123");

			string response = SendData("", "Author", "r"); //массив авторов
			authors = JsonConvert.DeserializeObject<List<Author>>(response);

			foreach (Author a in authors)
			{
				comboBox1.Items.Add(a.Name);
				selectArray.Add(a.Id);
			}
		}

		private void textBox1_TextChanged_1(object sender, EventArgs e)
		{

		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			
		}

		
		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void label12_Click(object sender, EventArgs e)
		{

		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();

			int authorId = 0;
			if (authors.Find(x => x.Name == comboBox1.Text) == null)
			{
				authorId = -1;
			} else
			{
				authorId = authors.Find(x => x.Name == comboBox1.Text).Id;
			}
			
			Book book = new Book {
				Id = 0,
				Name = textBox7.Text,
				Genre = comboBox2.Text,
				AuthorId = authorId,
				PublicationDate = dateTimePicker2.Value
			};
			string json_str = new JavaScriptSerializer().Serialize(book);
					
			string response = SendData(json_str, "Book", "r"); //массив книг

			List<Book> books = new List<Book>();
			books = JsonConvert.DeserializeObject<List<Book>>(response);

			foreach (Book b in books)
			{
				dataGridView1.Rows.Add(b.Name, authors.Find(x => x.Id == b.AuthorId).Name, b.Genre, b.PublicationDate);
			}

			if (books.Count() == 1)
			{
				richTextBox1.Text = authors.Find(x => x.Id == books[0].AuthorId).Description;
			}
			else
			{
				richTextBox1.Text = "Empty";
			}
		}

		private void label14_Click(object sender, EventArgs e)
		{

		}
	}
		
}

/*
 * TABLE book
 * id
 * genre
 * name
 * publication date
 * authorId
 * 
 * TABLE Author
 * id
 * name
 * surname
 * description
 * 
 * */


