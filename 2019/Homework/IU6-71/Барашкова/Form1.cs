using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowDZ
{
    public partial class Form1 : Form
    {
        string named, surnamed;
        int aged;
        string gender, conc;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void surname_TextChanged(object sender, EventArgs e)
        {

        }

        private void age_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql, Output = "";
            SqlCommand command;
            SqlDataReader dataRead;
            if ((name.Text == "") || (surname.Text == "") || (age.Value == 0))
            { MessageBox.Show("Введите все параметры"); }
            else
            {
                named = name.Text;
                surnamed = surname.Text;
                aged = Decimal.ToInt16(age.Value);
                if (radioButton1.Checked)
                { gender = "Мужской"; }
                else { gender = "Женский"; }
                conc = $"'{surnamed}', '{named}', {aged}, '{gender}'";
                MessageBox.Show(conc, "Запись в БД");
                string connetionString;
                SqlConnection cnn;
                connetionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True;";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                sql = "insert into [User] (name, surname, age, gender) values" + "(" + conc + ")";
                command = new SqlCommand(sql, cnn);
                int count = command.ExecuteNonQuery();
                sql = "Select id,name,surname,age,gender from [user]";
                command = new SqlCommand(sql, cnn);
                dataRead = command.ExecuteReader();
                while (dataRead.Read())
                {
                    Output = Output + dataRead.GetValue(1) + ", " + "\n";
                }
                MessageBox.Show(Output);
                cnn.Close();
            }
        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
