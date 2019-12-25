using System.Data.Linq.Mapping;

namespace Utility
{
    /// <summary>
    /// Датчик
    /// </summary>
    [Table(Name = "Sensors")]
    public class Sensor
    {
        /// <summary>
        /// Уникальный идентификатор датчика
        /// </summary>
        [Column(Storage = "Sensor_uuid", IsPrimaryKey = true, CanBeNull = false)]
        public string Sensor_uuid { get; set; }

        /// <summary>
        /// Идентификатор родительского источника
        /// </summary>
        [Column(Storage = "Parent_source_uuid", CanBeNull = false)]
        public string Parent_source_uuid { get; set; }

        /// <summary>
        /// Состояние датчика
        /// </summary>
        [Column(Storage = "State")]
        public string State { get; set; }
        
    }
}
