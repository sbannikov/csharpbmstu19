using System.Data.Linq.Mapping;

namespace Utility
{
    /// <summary>
    /// Значения параметра
    /// </summary>
    [Table(Name = "Values")]
    public class Value<T>
    {
        /// <summary>
        /// Уникальный идентификатор значения показания
        /// </summary>
        [Column(Storage = "Value_uuid", IsPrimaryKey = true, CanBeNull = false)]
        public string Value_uuid { get; set; }
        
        /// <summary>
        /// Идентефикатор родительского показателя
        /// </summary>
        [Column (Storage = "Parent_parameter_uuid", CanBeNull = false)]
        public string Parent_parameter_uuid { get; set; }

        /// <summary>
        /// Отметка времени начала усреднения значения показания
        /// </summary>
        [Column(Storage = "Timestamp_start")]
        public int Timestamp_start { get; set; }

        /// <summary>
        /// Отметка времени окончания усреднения значения показания
        /// </summary>
        [Column(Storage = "Timestamp_end")]
        public int Timestamp_end { get; set; }
        
        /// <summary>
        /// Значение показания
        /// </summary>
        [Column(Storage = "Data")]
        public T Data { get; set; }
    }
}
