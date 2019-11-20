using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Console
{
    class Program
    {
        /// <summary>
        /// Имя добавляемого пользователя
        /// </summary>
        private const string name = @"BMSTU\SBannikov";

        static void Main(string[] args)
        {
            try
            {
                // Создание объекта БД
                Core.Entities db = new Core.Entities();

                // Список кнопок
                foreach (var button in db.Buttons.OrderBy(a => a.Post).ThenBy(a => a.Side).ToList())
                {
                    System.Console.WriteLine(button);
                }

                Core.Users user;

                // Проверка на существование пользователя в базе данных
                user = db.Users.Where(a => a.Name == name).FirstOrDefault();

                if (user == null)
                {

                    // Добавление нового пользователя
                    user = new Core.Users()
                    {
                        Name = name,
                        AccessList = 2047,
                        ID = Guid.NewGuid()
                    };
                    db.Users.Add(user);
                }
                else
                {
                    user.AccessList = 2047;
                }

                user = db.Users.Where(a => a.Name == @"PTZ-MIDSRV\Zharkova").FirstOrDefault();
                if (user != null)
                {
                    db.Users.Remove(user);
                }

                db.SaveChanges();

                // Отображение списка пользователей
                foreach (var u in db.Users
                    // .Where(a => a.Name.Substring(0, 1) == "B")
                    .OrderBy(a => a.Name)
                    .ToList())
                {
                    System.Console.WriteLine(u);
                }

                System.Console.WriteLine(db.MediaPlayerStatus.Count());
                foreach (var item in db.MediaPlayerStatus.Take(10).ToList())
                {
                    System.Console.WriteLine(item.TimeStamp);
                }
            }
            catch (Exception ex)
            {
                do
                {
                    System.Console.WriteLine(ex.Message);
                    ex = ex.InnerException;
                }
                while (ex != null);
            }
            finally
            {
                System.Console.ReadLine();
            }
        }
    }
}
