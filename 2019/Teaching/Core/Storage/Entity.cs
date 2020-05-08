using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Bmstu.IU6.Teaching.Storage
{
    /// <summary>
    /// Сущность базы данных
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Конструктор по умолчаению
        /// </summary>
        public Entity()
        {
            // Генерация нового уникального идентификатора
            ID = Guid.NewGuid();
        }

        /// <summary>
        /// Полное название объекта
        /// </summary>
        /// <returns></returns>
        public virtual string GetName()
        {
            return $"Сущность {ID}";
        }
    }
}
