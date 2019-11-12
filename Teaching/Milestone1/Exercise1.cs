using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching
{
    public class Exercise1 : Exercise.Exercise0
    {   
        /// <summary>
        /// Генерация первого задания
        /// </summary>
        public void Run1(bool init)
        {
            if (init)
            {
                // Предварительная очистка списка
                db.Exercise1.RemoveRange(db.Exercise1.ToList());
            }

            // Общее количество сотрудников
            int characterCount = db.Characters.Count();

            // Число ролей
            int roleCount = db.Roles.Count();

            // Формирование задания для каждого студента
            foreach (var student in db.Students.
                Where(a => a.Mark).
                OrderBy(a => a.Family).
                ThenBy(a => a.Name).
                ToList())
            {
                Console.Write(".");

                // Список сотрудников
                List<int> characters = Helper.Randoms(roleCount, characterCount);

                // Формирование вариванта задания для каждой из шести ролей
                for (int n = 1; n <= roleCount; n++)
                {
                    int aCount = db.Abilities.Where(a => a.Role.Number == n).Count();
                    Storage.Exercise1 e1;
                    do
                    {
                        // Вектор способностей
                        List<int> abilities = Helper.Randoms(2, aCount);
                        int a1 = abilities[0];
                        int a2 = abilities[1];

                        // Номер сотрудника
                        int cnumber = characters[n - 1];

                        e1 = new Storage.Exercise1()
                        {
                            Role = db.Roles.Where(a => a.Number == n).First(),
                            Character = db.Characters.Where(a => a.Number == cnumber).First(),
                            Ability1 = db.Abilities.Where(a => a.Role.Number == n && a.Number == a1).First(),
                            Ability2 = db.Abilities.Where(a => a.Role.Number == n && a.Number == a2).First(),
                            Student = student
                        };
                        e1.Code = e1.GetCode();
                    }
                    while (db.Exercise1.Where(a => a.Code == e1.Code).FirstOrDefault() != null);
                    db.Exercise1.Add(e1);
                }
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
            var code = new Exercise.Code(db,1);

            // Формирование выходного CSV-файла
            using (var wrt = new System.IO.StreamWriter(@"rk1.txt", false))
            {
                // Формирование заголовка файла
                string s;
                s = "Студент;Группа;Код;";

                // Задание 1
                for (int i = 1; i <= 6; i++)
                {
                    s += $"И{i};Т{i};К{i}1;К{i}2;";
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
                    var list = db.Exercise1.Where(a => a.Student.ID == student.ID).OrderBy(a => a.Character.Name).ToList();
                    foreach (Storage.Exercise1 e in list)
                    {
                        s += $"{e.Character.Name};{e.Character.Number};{e.Ability1.Name};{e.Ability2.Name};";
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
