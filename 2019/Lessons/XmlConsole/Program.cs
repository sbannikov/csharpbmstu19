using System;
// using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlConsole
{
    class Program
    {
        /// <summary>
        /// Имя XML-файла
        /// </summary>
        private const string FileName = @"C:\TEST.XML";

        /// <summary>
        /// Главная функция
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Список (пример конструирования объекта из шаблона класса)
            var list = new System.Collections.Generic.List<string>();

            // Создание объекта с использованием инициализатора
            var s = new Sensor()
            {
                Number = 1,
                Description = "Печная термопара",              
                SType = SensorType.ThermoCouple,
                Data = new[]
                {
                    new Data() { Value = 20, TimeStamp = DateTime.Today},
                    new Data() { Value = 500, TimeStamp = DateTime.Now},
                }
            };

            // Сохранение в XML
            s.Save(FileName);

            // Сохранение в JSON
            s.JsonString(@"c:\json.json");

            // Чтение из XML
            Sensor s1 = Sensor.Load(FileName);

            Console.WriteLine(s1);

            Console.ReadLine();
        }
    }
}
