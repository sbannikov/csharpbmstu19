using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching.Storage
{
    /// <summary>
    /// Проектная роль
    /// </summary>
    public class Role : NamedEntity
    {
        /// <summary>
        /// Номер роли (от 1 до 6)
        /// </summary>
        [Range(1, 6)]
        public int Number { get; set; }
    }
}
