using System.Data.Linq.Mapping;

namespace Utility
{
    /// <summary>
    /// Источник выбросов
    /// </summary>
    [Table(Name = "Sources")]
    public class Source
    {
        /// <summary>
        /// Уникальный идентификатор источника выбросов
        /// </summary>
        [Column(Storage = "Source_uuid", IsPrimaryKey = true, CanBeNull = false)]
        public string Source_uuid { get; set; }
        
        /// <summary>
        /// Порядковый номер источника выбросов
        /// </summary>
        [Column(Storage = "Pniv")]
        public int Pniv { get; set; }
    }
}
