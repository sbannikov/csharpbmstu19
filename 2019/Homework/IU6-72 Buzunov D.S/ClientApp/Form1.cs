using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace ClientApp
{
    public partial class MainForm : Form
    {
        static ComboBoxData cbd;
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Проверка введенных данных и их сохранение в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Проверка на заполненность всех полей
            if (sourceBox.SelectedIndex < 0 ||
                sensorBox.SelectedIndex < 0 ||
                paramBox.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(valueBox.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка ввода",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Выбранный источник
                var src = (Source)sourceBox.SelectedItem;
                //Выбранный датчик
                var snr = (Sensor)sensorBox.SelectedItem;
                snr.Parent_source_uuid = src.Source_uuid;

                //Проверка датчика на неисправеность
                if (snr.State != "OK")
                {
                    MessageBox.Show("Датчик неисправен. Статус: " + snr.State, "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Выбранный параметр
                var prm = (Parameter)paramBox.SelectedItem;
                prm.Parent_sensor_uuid = snr.Sensor_uuid;
                
                //Введенное значение параметра
                string vbText = valueBox.Text;
                dynamic val = null;

                //Создание объекта "Значение" в зависимости от типа значения параметра
                switch (prm.Type)
                {
                    case "string":
                        switch (vbText.ToUpper())
                        {
                            case "OK":
                            case "ERROR":
                            case "MAINTENANCE":
                                val = new Value<string>()
                                {
                                    Value_uuid = UUIDGenerator.RandomID(),
                                    Timestamp_start = 0,
                                    Timestamp_end = 1,
                                    Parent_parameter_uuid = prm.Parameter_uuid,
                                    Data = vbText.ToUpper()
                                };
                                break;
                            default:
                                MessageBox.Show("Некорректное значение параметра", "Ошибка ввода",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                        break;
                    case "float":
                        try
                        {
                            val = new Value<float>()
                            {
                                Value_uuid = UUIDGenerator.RandomID(),
                                Timestamp_start = 0,
                                Timestamp_end = 1,
                                Parent_parameter_uuid = prm.Parameter_uuid,
                                Data = float.Parse(vbText, CultureInfo.InvariantCulture)
                            };
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Некорректное значение параметра", "Ошибка ввода",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        break;
                };

                //Данные введены корректно
                //Можно работать с объектами:
                //  -> src (Источник выбросов)
                //  -> snr (Датчик)
                //  -> prm (Параметер)
                //  -> val (Значение параметра)
                
                //Здесь реализуется запись в БД

            }

        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Инициализация выбираемых значений полей формы
            cbd = new ComboBoxData();

            sourceBox.DataSource = cbd.sources;
            sourceBox.DisplayMember = "Source_uuid";

            sensorBox.DataSource = cbd.sensors;
            sensorBox.DisplayMember = "Sensor_uuid";

            paramBox.DataSource = cbd.parameters;
            paramBox.DisplayMember = "Code";
        }
    }
}
