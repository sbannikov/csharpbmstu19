using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvpApp.Storage
{
    public class Group : Entity
    {
        /// <summary>
        /// Номер группы
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Кафедра
        /// </summary>
        
        public virtual Chair Chair { get; set; }
    }
}