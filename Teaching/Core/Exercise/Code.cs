using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching.Exercise
{
    /// <summary>
    /// Задание на исправление программного кода
    /// </summary>
    public class Code
    {
        /// <summary>
        /// Список номеров строк кода
        /// </summary>
        private readonly List<int> rows;

        /// <summary>
        /// Номер задания
        /// </summary>
        private readonly int number;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="db">База данных</param>
        /// <param name="n">Номер задания</param>
        public Code(Storage.DB db, int n)
        {
            number = n;
            rows = db.CodeRows.Where(a => a.Number == number).Select(a => a.Row).OrderBy(a => a).Distinct().ToList();
        }

        /// <summary>
        /// Заголовок CSV-файла
        /// </summary>
        /// <returns></returns>
        public string Header()
        {
            string s = "";
            for (int i = 0; i < rows.Count(); i++)
            {
                s += $"R{rows[i]};";
            }
            return s;
        }

        /// <summary>
        /// Строка CSV-файла
        /// </summary>
        /// <param name="db">База данных</param>
        /// <returns></returns>
        public string Row(Storage.DB db, Random rnd)
        {
            string s = "";
            for (int i = 0; i < rows.Count(); i++)
            {
                // Номер строки кода
                int row = rows[i];
                // Количество вариантов
                int versions = db.CodeRows.Where(a => (a.Number == number) && (a.Row == row)).Count();
                // Случайный выбор варианта
                int version = rnd.Next(1, versions + 1);
                // Загрузка варианта
                var code = db.CodeRows.Where(a => (a.Number == number) && (a.Row == row) && (a.Version == version)).First();
                // Кавычки следует удвоить
                s += "\"" + code.Code.Replace("\"", "\"\"") + "\";";
            }
            return s;
        }
    }
}
