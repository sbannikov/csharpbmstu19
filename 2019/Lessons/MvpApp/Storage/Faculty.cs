using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvpApp.Storage
{
    /// <summary>
    /// Факультет
    /// </summary>
    public class Faculty : Entity   
    {
        /// <summary>
        /// Код факультета
        /// </summary>
        [Required()]
        [MaxLength(7)]
        [Display(Name = "Код факультета")]
        public string Code { get; set; }

        /// <summary>
        /// Название факультета
        /// </summary>
        [Required()]
        [MaxLength(127)]
        [Display(Name = "Название факультета")]
        public string Name { get; set; }
    }
}
