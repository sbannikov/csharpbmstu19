using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching.Exercise
{
    /// <summary>
    /// Формирование задания студентам
    /// </summary>
    public abstract class Exercise0
    {
        /// <summary>
        /// База данных
        /// </summary>
        protected Storage.DB db = new Storage.DB();

        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        protected Random rnd = new Random();           
    }
}
