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
        [Required()]
        public string Family { get; set; }

        /// <summary>
        /// Группа
        /// </summary>
        [MaxLength(16)]
        [Required()]
        public string Group { get; set; }

        /// <summary>
        /// Личное дело
        /// </summary>
        [MaxLength(16)]
        [Required()]
        public string FileNumber { get; set; }

        /// <summary>
        /// Пометка для обработки
        /// </summary>
        public bool Mark { get; set; }

        /// <summary>
        /// Фамилия и имя
        /// </summary>
        public string FullName
        {
            get
            {
                return $"{Family} {Name}";
            }
        }

        /// <summary>
        /// Номер личного дела для генерации штрих-кода
        /// </summary>
        public string Code
        {
            get
            {
                string s = FileNumber;
                // Замена некорректных символов
                s = s.Replace("И", "I");
                s = s.Replace("У", "U");
                return s;
            }
        }
    }
}
