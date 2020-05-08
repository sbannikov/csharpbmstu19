using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Teaching
{
    /// <summary>
    /// Набор вспомогательных функций
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private static Random rnd = new Random();

        /// <summary>
        /// Генерация вектора неповторяющихся случайных чисел заданной длины
        /// </summary>
        /// <param name="count"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static List<int> Randoms(int count, int max)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= count; i++)
            {
                int n;
                do
                {
                    n = rnd.Next(1, max + 1);
                }
                while (list.Contains(n));
                list.Add(n);
            }

            return list;
        }
    }
}
