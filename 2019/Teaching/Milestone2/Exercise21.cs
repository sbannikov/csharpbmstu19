using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching
{
    /// <summary>
    /// Формирование 
    /// </summary>
    class Exercise21 : Exercise.Exercise0
    {  
        /// <summary>
        /// Генерация первого задания
        /// </summary>
        public void Run1()
        {
            // Формирование задания для каждого студента
            foreach (var student in db.Students.
                Where(a => a.Mark).
                OrderBy(a => a.Family).
                ThenBy(a => a.Name).
                ToList())
            {
                // Очистка старых данных
                var old = db.Exercise21.Where(a => a.Student.ID == student.ID).ToList();
                db.Exercise21.RemoveRange(old);

                var list = Helper.Randoms(12, 12);
                for (int i = 0; i < 12; i++)
                {
                    int n = list[i];
                    var p = db.Principles.Where(a => a.Number == n).First();
                    var e = new Storage.Exercise21()
                    {
                        Student = student,
                        Principle = p,
                        Number = i
                    };
                    db.Exercise21.Add(e);
                }

                Console.Write(".");
            }

            // Сохранить изменения
            db.SaveChanges();

            Console.WriteLine();
        }

        /// <summary>
        /// Генерация выходного файла
        /// </summary>
        public void Run()
        {
            // Список номеров строк
            var code = new Exercise.Code(db, 2);

            // Формирование выходного CSV-файла
            using (var wrt = new System.IO.StreamWriter(@"rk2.txt", false))
            {
                // Формирование заголовка файла
                string s;
                s = "Студент;Группа;Код;";

                // Задание 1
                for (int i = 1; i <= 12; i++)
                {
                    s += $"П{i};";
                }
                // Задание 2
                s += code.Header();

                wrt.WriteLine(s);

                // Формирование задания для каждого студента
                foreach (var student in db.Students.Where(a => a.Mark).OrderBy(a => a.Family).ThenBy(a => a.Name).ToList())
                {
                    Console.Write(".");

                    // Студент
                    s = student.Csv;

                    // Задание 1
                    var list = db.Exercise21.Where(a => a.Student.ID == student.ID).OrderBy(a => a.Number).ToList();
                    foreach (var e in list)
                    {
                        s += "\""+e.Principle.Name+ "\";";
                    }
                    
                    // Задание 2
                    s += code.Row(db, rnd);

                    // Запись строки
                    wrt.WriteLine(s);
                }
            }

            Console.WriteLine();
        }
    }
}
