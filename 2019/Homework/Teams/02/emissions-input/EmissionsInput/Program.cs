using EmissionsLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EmissionsInput
{
    static class Program
    {
        public static int ProgramStartTime = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (Source.Get(Helper.ConnectionStringValue("emissionsDb")).Count == 0)
                {
                    SeedDb();

                    Helper.ShowInfo("База данных инициализированна.", "Успешная запись в базу данных");
                }
            }
            catch
            {
                var dialog = Helper.ShowDbError("Ошибка инициализации базы данных");
                
                if (dialog == DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        // Заполняет базу данных начальными данными
        private static void SeedDb()
        {
            var dbConnectionString = Helper.ConnectionStringValue("emissionsDb");

            // Создать источники выбросов
            var sources = new List<Source>();

            for (int i = 0; i < 3; i++)
            {
                var newSource = new Source() { pniv = i + 1 };
                sources.Add(newSource);

                Source.Create(dbConnectionString, newSource);
            }

            // Создать датчики для каждого источника выбросов
            var sensors = new List<Sensor>();
            var random = new Random();

            sources.ForEach(delegate (Source source)
            {
                for (int i = 0; i < 6; i++)
                {
                    var newSensor = new Sensor()
                    {
                        sourceUuid = source.sourceUuid,
                        state = Helper.States[random.Next(0, Helper.States.Length)]
                    };
                    sensors.Add(newSensor);

                    Sensor.Create(dbConnectionString, newSensor);
                }
            });

            // Создать параметры для каждого датчика
            var parameters = new List<Parameter>();

            sensors.ForEach(delegate (Sensor sensor)
            {
                parameters.AddRange(Helper.GenerateParameters(sensor.sensorUuid));
            });

            parameters.ForEach(delegate (Parameter parameter)
            {
                Parameter.Create(dbConnectionString, parameter);
            });
        }
    }
}
