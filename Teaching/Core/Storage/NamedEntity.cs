using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching.Storage
{
    /// <summary>
    /// Именованая сущность
    /// </summary>
    public abstract class NamedEntity :Entity
    {
        /// <summary>
        /// Название
        /// </summary>
        [MaxLength(255)]
        [DisplayName("Название")]
        public string Name { get; set; }

        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
