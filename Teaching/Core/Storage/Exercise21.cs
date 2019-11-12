using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching.Storage
{
    /// <summary>
    /// Задание № 1 РК2
    /// </summary>
    public class Exercise21 : Exercise
    {
        /// <summary>
        /// Принцип
        /// </summary>
        [Required()]
        public virtual Principle Principle { get; set; }

        /// <summary>
        /// Номер по порядку в задании
        /// </summary>
        public int Number { get; set; }
    }
}
