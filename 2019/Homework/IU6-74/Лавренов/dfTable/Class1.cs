using System;
//файлы для работы с файлами
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using System.Web;

using System.Text.RegularExpressions;
using udplocalsend;
using System.Net.Sockets;

public class PrintTable
{
    string FileName;
    public PrintTable(string name)
    {
        FileName = new string(name);
    }
    //количество копий файлов отчёта. Для того, чтобы отчёты нумеровались, а не перезаписывались при создании
    int reportCopies = 1;

    //флаг, указывающий был произведён расчёт или нет
    bool _solveIsDone = false,
        _tableIsFilled = false;


    //Список для составления отчёта
    List<List<string>> reportList = new List<List<string>>();//динамический двумерный массив


    public PrintTable()
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

            //=проверка на наличие файла=====================Если есть создать новый с подписью какой по счету это вариант файла	
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

            //пример добавления подписи с подчеркиванием полужирным шрифтом 14 кегеля
            Phrase orgName = new Phrase("                                                  Приложение А                                                  /n",
                new iTextSharp.text.Font(fgTimesbdBaseFont, 14));
            doc.Add(orgName);


            //Таблица=====================

            #region таблица
            //////////////////////////////////////////////////////////////////
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;//Таблица занимает всю ширину листа
            int leading = 10;//размер шрифта 

            table.AddCell(new Phrase("Хеш сумма программы", new iTextSharp.text.Font(fgTimesBaseFont, leading)));

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
    private void createRowInReportTable(PdfPTable table, string parameter1, string parameter2, string parameter3, string parameter4, string parameter5, string parameter6, string parameter7, string parameter8, string parameter9, string parameter10, string parameter11, string parameter12, string parameter13, string parameter14)
    {
        table.AddCell(parameter1);
        table.AddCell(parameter2);
        table.AddCell(parameter3);
        table.AddCell(parameter4);
        table.AddCell(parameter5);
        table.AddCell(parameter6);
        table.AddCell(parameter7);
        table.AddCell(parameter8);
        table.AddCell(parameter9);
        table.AddCell(parameter10);
        table.AddCell(parameter11);
        table.AddCell(parameter12);
        table.AddCell(parameter13);
        table.AddCell(parameter14);
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


}
