using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyService
{
    public class Result
    {
        /// <summary>
        /// Значение
        /// </summary>
        public double Value;

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string Message;

        /// <summary>
        /// Признак корректност результата
        /// </summary>
        public bool Valid;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Result() {
            Value = double.NaN;
            Valid = false;
        }

        public Result(double x)
        {
            Value = x;
            Valid = true;
        }

        public Result(Exception ex)
        {
            Message = ex.Message;
            Value = double.NaN;
            Valid = false;
        }

    }
}