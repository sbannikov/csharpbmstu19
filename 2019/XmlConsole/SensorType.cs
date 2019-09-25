using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlConsole
{
    public enum SensorType
    {
        /// <summary>
        /// Не задано
        /// </summary>
        None,
        /// <summary>
        /// Термопара
        /// </summary>
        ThermoCouple,
        /// <summary>
        /// Датчик теплового потока
        /// </summary>
        HeatFlow
    }
}
