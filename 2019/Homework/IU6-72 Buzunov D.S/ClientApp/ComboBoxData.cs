using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace ClientApp
{
    /// <summary>
    /// Данные для отображения/выбора на форме
    /// </summary>
    class ComboBoxData
    {
        public List<Source> sources;
        public List<Sensor> sensors;
        public List<Parameter> parameters;

        public ComboBoxData()
        {
            sources = new List<Source>();
            sensors = new List<Sensor>();
            parameters = new List<Parameter>();

            //Добавляем источники
            sources.Add(new Source()
            {
                Source_uuid = UUIDGenerator.RandomID(),
                Pniv = 1
            });

            //Добавляем сенсоры
            sensors.Add(new Sensor()
            {
                Sensor_uuid = UUIDGenerator.RandomID(),
                State = "OK"
            });
            sensors.Add(new Sensor()
            {
                Sensor_uuid = UUIDGenerator.RandomID(),
                State = "MAINTENANCE"
            });

            //Добавляем параметры
            parameters.Add(new Parameter()
            {
                Parameter_uuid = UUIDGenerator.RandomID(),
                Code = "H2SkgPerHour",
                Unit = "kgPH",
                Type = "float"
            });
            parameters.Add(new Parameter()
            {
                Parameter_uuid = UUIDGenerator.RandomID(),
                Code = "SO2kgPerHour",
                Unit = "kgPH",
                Type = "float"
            });
            parameters.Add(new Parameter()
            {
                Parameter_uuid = UUIDGenerator.RandomID(),
                Code = "SuspendedParticulateskgPerHour",
                Unit = "kgPH",
                Type = "float"
            });
            parameters.Add(new Parameter()
            {
                Parameter_uuid = UUIDGenerator.RandomID(),
                Code = "NOxkgPerHour",
                Unit = "kgPH",
                Type = "float"
            });
            parameters.Add(new Parameter()
            {
                Parameter_uuid = UUIDGenerator.RandomID(),
                Code = "COxFuelkgPerHour",
                Unit = "kgPH",
                Type = "float"
            });
            parameters.Add(new Parameter()
            {
                Parameter_uuid = UUIDGenerator.RandomID(),
                Code = "COxkgPerHour",
                Unit = "kgPH",
                Type = "float"
            });
            parameters.Add(new Parameter()
            {
                Parameter_uuid = UUIDGenerator.RandomID(),
                Code = "HFkgPerHour",
                Unit = "kgPH",
                Type = "float"
            });
            parameters.Add(new Parameter()
            {
                Parameter_uuid = UUIDGenerator.RandomID(),
                Code = "HClkgPerHour",
                Unit = "kgPH",
                Type = "float"
            });
            parameters.Add(new Parameter()
            {
                Parameter_uuid = UUIDGenerator.RandomID(),
                Code = "NH3kgPerHour",
                Unit = "kgPH",
                Type = "float"
            });
            parameters.Add(new Parameter()
            {
                Parameter_uuid = UUIDGenerator.RandomID(),
                Code = "ElectronicSealState",
                Unit = "State",
                Type = "string"
            });
        }
    }
}
