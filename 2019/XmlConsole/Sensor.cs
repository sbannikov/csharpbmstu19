using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace XmlConsole
{
    /// <summary>
    /// Датчик
    /// </summary>
    [XmlRoot(ElementName = "ThermoCouple", Namespace = "http://www.bmstu.ru")]
    [DataContract()]
    public class Sensor
    {
        /// <summary>
        /// Номер датчика (поле)
        /// </summary>
        private int number;

        /// <summary>
        /// Номер датчика - пример реализации свойства
        /// </summary>
        [XmlAttribute(AttributeName = "ID")]
        [DataMember(Name = "ID")]
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (number < 0)
                {
                    throw new Exception("Все плохо");
                }
                number = value;
            }
        }

        /// <summary>
        /// Массив данных
        /// </summary>
        [XmlElement()]
        [DataMember()]
        public Data[] Data { get; set; }

        [DataMember(Name = "SensorType")]
        public SensorType SType { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [DataMember()]
        public string Description { get; set; }

        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Датчик {Number}";
        }

        /// <summary>
        /// Загрузка объекта из XML-файла
        /// </summary>
        /// <param name="name">Имя XML-файла</param>
        /// <returns></returns>
        public static Sensor Load(string name)
        {
            XmlSerializer s = new XmlSerializer(typeof(Sensor));
            using (XmlReader rdr = XmlReader.Create(name))
            {
                return (Sensor)s.Deserialize(rdr);
            }
        }

        /// <summary>
        /// Сохранение объекта в XML-файл
        /// </summary>
        /// <param name="name">Имя XML-файла</param>
        public void Save(string name)
        {
            XmlSerializer s = new XmlSerializer(GetType());
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true
            };
            using (XmlWriter wrt = XmlWriter.Create(name, settings))
            {
                s.Serialize(wrt, this);
            }
        }

        /// <summary>
        /// Сохранение объекта в JSON-файл
        /// </summary>
        /// <param name="name">Имя JSON-файла</param>
        public void JsonString(string name)
        {
            var s = new DataContractJsonSerializer(GetType());
            using (var wrt = System.IO.File.Create(name))
            {
                s.WriteObject(wrt, this);
            }
        }
    }
}
