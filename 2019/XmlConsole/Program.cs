using System;
// using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlConsole
{
    class Program
    {
        private const string FileName = @"C:\TEST.XML";

        static void Main(string[] args)
        {
            // Список
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

            s.Save(FileName);
            s.JsonString(@"c:\json.json");

            Sensor s1 = Sensor.Load(@"C:\TEST1.XML");

            Console.WriteLine(s1);

            Console.ReadLine();
        }
    }
}
