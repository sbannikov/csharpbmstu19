using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//файлы для работы с файлами
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using System.Web;

using System.Text.RegularExpressions;
//using udplocalsend;
using System.Net.Sockets;

namespace dfTable
{
    public partial class Form1 : Form
    {
        //количество копий файлов отчёта.
        int reportCopies = 1;

        //флаг, указывающий был произведён расчёт или нет
        bool _tableIsFilled = false;


        //Список для составления отчёта
        List<List<string>> reportList = new List<List<string>>();//динамический двумерный массив

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Создание файла";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(81, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Выбрать папку";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 22);
            this.textBox1.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(81, 67);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Считать данные";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(51, 96);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(177, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Очистить данные в программе";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 164);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                //создаём диалоговое окно открытия файла
                OpenFileDialog ofd = new OpenFileDialog();
                //Открываем диалоговое окно
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = ofd.FileName;
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string reportFileName = "Test(Название файла)" + " (" + DateTime.Now.ToShortDateString() + ")";
            try
            {
                #region добавление шрифта для кириллицы

                //обычный
                string fgTimes = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.TTF");//путь к шрифту на компьютере
                BaseFont fgTimesBaseFont = BaseFont.CreateFont(fgTimes, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);//создание шрифта в программе на основе шрифта по пути в компьютере
                iTextSharp.text.Font timesFont_Test = new iTextSharp.text.Font(fgTimesBaseFont, 10);//создание параметров шрифта

                //полужирный
                string fgTimesbd = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "timesbd.TTF");//путь к шрифту на компьютере
                BaseFont fgTimesbdBaseFont = BaseFont.CreateFont(fgTimesbd, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);//создание шрифта в программе на основе шрифта по пути в компьютере
                iTextSharp.text.Font timesbdFont_Test = new iTextSharp.text.Font(fgTimesbdBaseFont, 10);//создание параметров шрифта

                //курсив
                string fgTimesi = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "timesi.TTF");//путь к шрифту на компьютере
                BaseFont fgTimesiBaseFont = BaseFont.CreateFont(fgTimesi, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);//создание шрифта в программе на основе шрифта по пути в компьютере
                iTextSharp.text.Font timesiFont_Test = new iTextSharp.text.Font(fgTimesiBaseFont, 10);//создание параметров шрифта
                #endregion

                //Создание документа
                Document doc = new Document(iTextSharp.text.PageSize.A4, 15, 15, 20, 20);
                //doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

                //=проверка на наличие файла=====================Если есть создать копию	
                //По умолчанию в той же директории где экзешник
                FileInfo reportFile = new FileInfo(Application.StartupPath + @"\" + reportFileName + ".pdf");

                if (reportFile.Exists)
                {
                    reportFileName += reportCopies.ToString();
                    reportCopies++;
                }
                else
                {
                    reportCopies = 1;
                }
                //===============================================


                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Application.StartupPath + @"\" + reportFileName + ".pdf", FileMode.CreateNew));

                doc.Open();

                //пример добавления подписи
                Phrase orgName = new Phrase("                                                                                                       Приложение А\n",
                    new iTextSharp.text.Font(fgTimesbdBaseFont, 14));
                doc.Add(orgName);


                //Таблица=====================

                #region таблица
                //////////////////////////////////////////////////////////////////
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;//Таблица занимает всю ширину листа
                int leading = 10;//размер шрифта 

                table.AddCell(new Phrase("Хеш сумма программы измерения", new iTextSharp.text.Font(fgTimesBaseFont, leading)));

                table.AddCell(new Phrase("Путь к .exe файлу", new iTextSharp.text.Font(fgTimesBaseFont, leading)));


                int countRowsInReport = 0;
                for (int i = 0; i < reportList.Count; i++)
                {
                    for (int j = 0; j < reportList[0].Count; j++)
                    {
                        createRowInReportTable(table, reportList[i][j]);
                    }
                    countRowsInReport++;
                }
                doc.Add(table);
                //////////////////////////////////////////////////////////////////
                #endregion


                //Подтверждение изменений в файле
                writer.DirectContent.Stroke();
                doc.Close();



                MessageBox.Show("Pdf-документ сохранен\n" + Application.StartupPath + @"\" + reportFileName, "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException)
            {
                MessageBox.Show("Файл с именем " + reportFileName + " уже существует", "Ошибка создания отчёта.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Закройте созданный ранее отчёт.", "Ошибка создания отчёта.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /// <summary>
        /// Создаёт в таблице новую строку для заполнения
        /// </summary>
        /// <param name="table"></param>
        private void createRowInReportTable(PdfPTable table, string parameter1, string parameter2)
        {
            table.AddCell(parameter1);
            table.AddCell(parameter2);
        }

        /// <summary>
        /// Создаёт в таблице новую строку для заполнения
        /// </summary>
        /// <param name="table"></param>
        private void createRowInReportTable(PdfPTable table, string parameter)
        {
            string fgTimes = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.TTF");//путь к шрифту на компьютере
            BaseFont fgTimesBaseFont = BaseFont.CreateFont(fgTimes, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);//создание шрифта в программе на основе шрифта по пути в компьютере
            iTextSharp.text.Font timesFont_Test = new iTextSharp.text.Font(fgTimesBaseFont, 8);//создание параметров шрифта

            Phrase phrs = new Phrase(parameter, timesFont_Test);

            table.AddCell(phrs);
        }
        //добавление строки с расчётами в таблицу

        private void button3_Click(object sender, EventArgs e)
        {

            string reportFileName = @"D:\ASUGSM\ASUGSM\bin\Debug\MD5SrcFiles.txt";// textBox1.ToString();
            reportFileName = textBox1.Text;
            try
            {
                //Добавляем строки в таблицу
                string str;
                str = reportFileName;
                StreamReader strem = new StreamReader(str);
                string[] parths;
                while ((str = strem.ReadLine()) != null)//Чтение из файла построчно
                {
                    List<string> reportRow = new List<string>(); //строка массива
                    parths = str.Split(new char[] { ' ' });
                    reportRow.Add(parths[2]);//хэш
                    int m = parths.Count();
                    for (int i = 5; i < m; i++)
                    {
                        parths[4] += parths[i];
                    }
                    reportRow.Add(parths[4]);//путь
                    reportList.Add(reportRow);
                }


                _tableIsFilled = true;
                MessageBox.Show("Данные успешно считаны.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException)
            {
                MessageBox.Show("Файл с именем " + reportFileName + " уже существует", "Ошибка создания отчёта.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка чтения данных.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Очистка таблицы отчета
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистить таблицу с отчётными данными?", "Очистка таблицы", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                reportList.Clear();
                _tableIsFilled = false;
            }
            else
            {
                return;
            }

        }

    }
}
