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

namespace employeeClient
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

				if (addType == "Book") {
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

		private void Form1_Load(object sender, EventArgs e)
		{
			comboBox1.Items.Add("Detective");
			comboBox1.Items.Add("Horror");
			comboBox1.Items.Add("Romance");
			comboBox1.Items.Add("Manga");
			comboBox1.Items.Add("Mystic");
			comboBox1.Items.Add("Adventure");
			comboBox1.Items.Add("Fairy tale");
			comboBox1.Items.Add("Biography");

			string response = SendData("", "Author", "r"); //массив авторов
			authors = JsonConvert.DeserializeObject<List<Author>>(response);

			foreach (Author a in authors)
			{			
				comboBox2.Items.Add(a.Name);
				selectArray.Add(a.Id);
			}

		}

		private void label10_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Author author = new Author();
			author.Name = textBox4.Text;
			author.Surname = textBox3.Text;
			author.Description = richTextBox1.Text;
			string json_str = new JavaScriptSerializer().Serialize(author);
			SendData(json_str, "Author", "w");
			textBox4.Text = "";
			textBox3.Text = "";
			richTextBox1.Text = "";

			string response = SendData("", "Author", "r"); //массив авторов
			authors = JsonConvert.DeserializeObject<List<Author>>(response);

			comboBox2.Items.Clear();
			foreach (Author a in authors)
			{
				comboBox2.Items.Add(a.Name);
				selectArray.Add(a.Id);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Book book = new Book();
			book.AuthorId = authors.Find(x => x.Name == comboBox2.Text).Id;
			book.Name = textBox2.Text;
			book.Genre = comboBox1.Text;
			book.PublicationDate = dateTimePicker1.Value;

			textBox2.Text = "";
			comboBox2.Text = "";
			comboBox1.Text = "";
			
			string json_str = new JavaScriptSerializer().Serialize(book);
			SendData(json_str, "Book", "w");
		}

		private void label14_Click(object sender, EventArgs e)
		{

		}
	}
}
