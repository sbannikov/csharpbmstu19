using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalcWeb
{
    public partial class Calculator : System.Web.UI.Page
    {
        /// <summary>
        /// Первый операнд
        /// </summary>
        private double x
        {
            get
            {
                object o = Session["x"];
                if (o != null)
                {
                    return (double)o;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                Session["x"] = value;
                // Для индикатора
                Indicator.Text = value.ToString();
            }
        }

        /// <summary>
        /// Второй операнд
        /// </summary>
        private double y
        {
            get
            {
                object o = Session["y"];
                if (o != null)
                {
                    return (double)o;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                Session["y"] = value;
            }
        }
        /// <summary>
        /// Признак ввода нового числа
        /// </summary>
        private bool newNumber
        {
            get
            {
                object o = Session["newNumber"];
                if (o != null)
                {
                    return (bool)o;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                Session["newNumber"] = value;
            }
        }

        /// <summary>
        /// Двухместная арифметическая операция
        /// </summary>
        private Operation operation
        {
            get
            {
                object o = Session["operation"];
                if (o != null)
                {
                    return (Operation)o;
                }
                else
                {
                    return Operation.None;
                }
            }
            set
            {
                Session["operation"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Нажатие на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Click(object sender, EventArgs e)
        {
            // Приведение типа
            Button b = (Button)sender;
            // Определение тега кнопки
            string tag = (string)b.Text;
            // Определение номера цифры
            double digit = double.Parse(tag);
            // Вычисление 
            if (newNumber)
            {
                x = digit;
                newNumber = false;
            }
            else
            {
                x = 10 * x + digit;
            }
        }
    }
}