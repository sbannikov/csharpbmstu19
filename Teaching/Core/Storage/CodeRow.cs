using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching.Storage
{
    /// <summary>
    /// Строка кода
    /// </summary>
    public class CodeRow : Entity
    {
        /// <summary>
        /// Номер задания
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Номер строки кода
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Вариант строки кода
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Строка кода
        /// </summary>
        [MaxLength(255)]
        [Required()]
        public string Code { get; set; }
    }
}
