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
    [XmlRoot(
        ElementName = "ThermoCouple",
        Namespace = "http://www.bmstu.ru")]
    [DataContract()]
    public class Sensor
    {
        private int number;

        /// <summary>
        /// Номер датчика
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

        public override string ToString()
        {
            return $"Датчик {Number}";
        }

        public static Sensor Load(string name)
        {
            XmlSerializer s = new XmlSerializer(typeof(Sensor));
            using (XmlReader rdr = XmlReader.Create(name))
            {
                return (Sensor)s.Deserialize(rdr);
            }
        }

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
