using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bmstu.IU6.Calculator
{
    /// <summary>
    /// Главная форма класса
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Первый операнд
        /// </summary>
        private int x;

        /// <summary>
        /// Второй операнд
        /// </summary>
        private int y;
        /// <summary>
        /// Признак ввода нового числа
        /// </summary>
        private bool newNumber;

        /// <summary>
        /// Двухместная арифметическая операция
        /// </summary>
        private Operation operation;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Инициализация полей
            x = 0;
            y = 0;
            newNumber = false;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Параметры события</param>
        private void buttonDigit_Click(object sender, EventArgs e)
        {
            // Приведение типа
            Button b = (Button)sender;
            // Определение тега кнопки
            string tag = (string)b.Tag;
            // Определение номера цифры
            int digit = int.Parse(tag);
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
            // Для индикатора
            indicator.Text = x.ToString();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            y = x;
            newNumber = true;
            // Приведение типа
            Button b = (Button)sender;
            // Определение тега кнопки
            string tag = (string)b.Tag;
            // Код операции
            operation = (Operation)Enum.Parse(typeof(Operation), tag);
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            try
            {
                switch (operation)
                {
                    case Operation.Addition:
                        x = x + y;
                        break;
                    case Operation.Division:
                        x = y / x;
                        break;
                    default:
                        break;
                }
                // Для индикатора
                indicator.Text = x.ToString();
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Нехорошо делить на ноль");
            }
            catch (Exception ex)
            {
                string m = $"{ex.GetType().FullName}: {ex.Message} {ex.StackTrace}";
                MessageBox.Show(m, "Калькулятор", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
