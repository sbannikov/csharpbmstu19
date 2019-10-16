using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Reflection;
using System.Configuration.Install;

namespace MyService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UsefulService svc;

                // Первый параметр командной строки
                string arg = args.Count() > 0 ? args[0] : string.Empty;
                arg = arg.ToLower().Trim();

                // Имя сервиса (исполняемого файла)
                string name = Assembly.GetExecutingAssembly().Location;

                switch (arg)
                {
                    case "install":
                        // Добавление сервиса
                        ManagedInstallerClass.InstallHelper(new string[] { name });
                        break;

                    case "delete":
                        // Удаление сервиса
                        ManagedInstallerClass.InstallHelper(new string[] { "/u", name });
                        break;

                    case "console":
                        // Создание объекта сервиса
                        svc = new UsefulService();
                        svc.StartService();
                        Console.WriteLine("Сервис запущен в консольном режиме");
                        Console.WriteLine("Для завершения нажмите Enter");
                        Console.ReadLine();
                        svc.Stop();
                        break;

                    default:
                        if (Environment.UserInteractive)
                        {
                            Console.WriteLine("Это сервис");
                            // дописать подсказку
                        }
                        else
                        {
                            // Создание объекта сервиса
                            svc = new UsefulService();

                            // Запуск сервиса
                            ServiceBase.Run(svc);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                if (Environment.UserInteractive)
                {
                    Console.WriteLine(ex.Message);
                }
                else
                {
                    // непонятно куда писать
                }
            }
        }
    }
}
