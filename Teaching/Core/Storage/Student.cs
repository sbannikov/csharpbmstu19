using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching.Storage
{
    /// <summary>
    /// Студен
    /// </summary>
    public class Student : NamedEntity
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        [MaxLength(255)]
        public string Family { get; set; }

        /// <summary>
        /// Группа
        /// </summary>
        [MaxLength(16)]
        public string Group{ get; set; }

        /// <summary>
        /// Личное дело
        /// </summary>
        public string FileNumber { get; set; }
    }
}
