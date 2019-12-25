using System.Data.Linq.Mapping;

namespace Utility
{
    /// <summary>
    /// Параметр
    /// </summary>
    [Table(Name = "Parameters")]
    public class Parameter
    {
        /// <summary>
        /// Уникальный идентификатор показания
        /// </summary>
        [Column(Storage = "Parameter_uuid", IsPrimaryKey = true, CanBeNull = false)]
        public string Parameter_uuid { get; set; }

        /// <summary>
        /// Идентификатор родительского датчика
        /// </summary>
        [Column(Storage = "Parent_sensor_uuid", CanBeNull = false)]
        public string Parent_sensor_uuid { get; set; }

        /// <summary>
        /// Тип показания
        /// </summary>
        [Column(Storage = "Code")]
        public string Code { get; set; }

        /// <summary>
        /// Единица измерения показания
        /// </summary>
        [Column(Storage = "Unit")]
        public string Unit { get; set; }
        
        /// <summary>
        /// Тип данных показания
        /// </summary>
        [Column(Storage = "Type")]
        public string Type { get; set; }
        
    }
}
