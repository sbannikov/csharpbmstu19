using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvpApp.Storage
{
    /// <summary>
    /// Кафедра
    /// </summary>
    public class Chair : Entity
    {
        /// <summary>
        /// Номер кафедры
        /// </summary>
        [Display(Name = "Номер кафедры")]
        [Index("IX_NUMBER", IsUnique = true)]
        [Range(1, 99)]
        public int Number { get; set; }

        /// <summary>
        /// Название кафедры
        /// </summary>
        [Required()]
        [MaxLength(127)]
        [Display(Name = "Название кафедры")]
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор факультета
        /// </summary>
        public Nullable<Guid> FacultyID { get; set; }

        /// <summary>
        /// Факультет
        /// </summary>
        [ForeignKey("FacultyID")]
        public virtual Faculty Faculty { get; set; }
    }
}