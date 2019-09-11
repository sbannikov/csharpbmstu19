using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmstu.IU6.Calculator
{
    /// <summary>
    /// Арифметические операции
    /// </summary>
    enum Operation
    {
        None = 0,
        Addition,
        Division
    }

    public static class OperationClass
    {
        public const int None = 0;
        public const int Addition = 1;
        public const int Division = 2;
    }
}
