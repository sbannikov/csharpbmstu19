using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlConsole
{
    /// <summary>
    /// Данные
    /// </summary>
    public class Data
    {
        public double Value { get; set; }

        /// <summary>
        /// Метка времени
        /// </summary>
        [XmlElement(ElementName = "DateTime")]
        public DateTime TimeStamp { get; set; }
    }
}
