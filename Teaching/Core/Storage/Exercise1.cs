using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching.Storage
{
    /// <summary>
    /// Задание № 1
    /// </summary>
    public class Exercise1 : Entity
    {
        /// <summary>
        /// Имя сотрудика
        /// </summary>
        public virtual Character Character { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// Первая способность
        /// </summary>
        public virtual Ability Ability1 { get; set; }

        /// <summary>
        /// Вторая способность
        /// </summary>
        public virtual Ability Ability2 { get; set; }

        /// <summary>
        /// Студент
        /// </summary>
        public virtual Student  Student { get; set; }

        /// <summary>
        /// Уникальный код задания
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Формирование кода задания
        /// </summary>
        /// <returns></returns>
        public string GetCode()
        {
            return $"{Role.Number}{Character.Number,2:00}{Ability1.Number}{Ability2.Number}";
        }
    }
}
