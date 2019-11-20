using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Core
{
    partial class Buttons
    {
        /// <summary>
        /// Строковое представление кнопки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Post} {Side} {Number}";
        }
    }
}
