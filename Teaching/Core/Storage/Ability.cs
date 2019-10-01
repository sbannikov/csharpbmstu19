using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching.Storage
{
    /// <summary>
    /// Способность (качество) сотрудника
    /// </summary>
    public class Ability : NamedEntity
    {
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        public Guid RoleID { get; set; }

        /// <summary>
        /// Проектная роль, для которой данное качество необходимо
        /// </summary>
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

        /// <summary>
        /// Код 
        /// </summary>
        public int Number{ get; set; }
    }
}
