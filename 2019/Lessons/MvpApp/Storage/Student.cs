using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvpApp.Storage
{
    /// <summary>
    /// Студент
    /// </summary>
    public class Student : Entity
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required()]
        [MaxLength(64)]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required()]
        [MaxLength(64)]
        public string FamilyName { get; set; }

        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public Guid GroupID { get; set; }

        /// <summary>
        /// Группа
        /// </summary>
        [ForeignKey("GroupID")]
        public virtual Group Group { get; set; }

        /// <summary>
        /// true - студент учится
        /// false - студент не учится (отчислен)
        /// </summary>
        public bool Active { get; set; }
    }
}