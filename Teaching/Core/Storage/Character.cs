using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching.Storage
{
    /// <summary>
    /// Участник проектной команды
    /// </summary>
    public class Character : NamedEntity
    {
        /// <summary>
        /// Номер 
        /// </summary>       
        public int Number { get; set; }
    }
}
