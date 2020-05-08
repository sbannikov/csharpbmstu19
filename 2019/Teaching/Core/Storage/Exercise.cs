using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching.Storage
{
    /// <summary>
    /// Задание, выданное конкретному студенту
    /// </summary>
    public class Exercise : Entity
    {
        /// <summary>
        /// Студент
        /// </summary>
        [Required()]
        public virtual Student Student { get; set; }
    }
}
