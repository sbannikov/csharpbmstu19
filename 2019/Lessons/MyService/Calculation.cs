using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
                double x = double.Parse(sx);
                double y = double.Parse(sy);
                return new Result(x + y);
            }
            catch (Exception ex)
            {
                return new Result(ex);
            }
        }
    }
}
