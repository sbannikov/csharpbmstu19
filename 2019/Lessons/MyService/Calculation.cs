using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Globalization;

namespace MyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Calculation" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class Calculation : ICalculation
    {
        public Result Addition(string sx, string sy)
        {
            try
            {
                double x, y;
                IFormatProvider format = CultureInfo.InvariantCulture;
                if (!double.TryParse(sx, NumberStyles.Float, format, out x))
                {
                    return new Result($"Параметр sx задан некорректно, ожидается число: {sx}");
                }
                if (!double.TryParse(sy, NumberStyles.Float, format, out y))
                {
                    return new Result($"Параметр sy задан некорректно, ожидается число: {sy}");
                }
                return new Result(x + y);
            }
            catch (Exception ex)
            {
                return new Result(ex);
            }
        }
    }
}
