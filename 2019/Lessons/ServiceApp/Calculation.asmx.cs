using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiceApp
{
    /// <summary>
    /// Summary description for Calculation
    /// </summary>
    [WebService(Namespace = "http://gvendolen.xyz")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Calculation : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// Сложение чисел
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [WebMethod(Description = "Сложение чисел")]
        public Result Addition(string sx, string sy)
        {
            try
            {
                double x = double.Parse(sx);
                double y = double.Parse(sy);
                return new Result (x + y);
            }
            catch (Exception ex)
            {
                return new Result(ex);
            }
        }
    }
}
