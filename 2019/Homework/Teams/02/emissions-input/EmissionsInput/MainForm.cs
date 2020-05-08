using EmissionsLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EmissionsInput
{
    public partial class MainForm : Form
    {
        List<Source> sources = new List<Source>();
        List<Sensor> sensors = new List<Sensor>();
        List<Parameter> parameters = new List<Parameter>();
        string parameterUuid = null;

        string dbConnectionString = Helper.ConnectionStringValue("emissionsDb");

        public MainForm()
        {
            InitializeComponent();
        }

        // Сохранение введнного значения
        private void saveButton_Click(object sender, EventArgs e)
        {
            string inputValue = valueTextBox.Text;

            if (inputValue.Length != 0)
            {
                Parameter selectedParameter = (Parameter)parametersDropDown.SelectedItem;
                if (selectedParameter.type == "float")
                {
                    try
                    {
                        float.Parse(inputValue);
                    }
                    catch
                    {
                        Helper.ShowParseError("Для данного параметра требуется тип float. Проверьте введенное значение.");
                        return;
                    }
                }
                else
                {
                    if (!Array.Exists(Helper.States, state => state == inputValue))
                    {
                        Helper.ShowParseError("Возможные значения для данного параметра: OK, ERROR, MAINTENANCE. Проверьте введенное значение.");
                        return;
                    }
                }

                Value newValue = new Value()
                {
                    value = inputValue,
                    parameterUuid = selectedParameter.parameterUuid,
                    timestampStart = Program.ProgramStartTime
                };

                try
                {
                    Value.Create(dbConnectionString, newValue);
                }
                catch
                {
                    Helper.ShowDbError("Ошибка записи в базу данных");
                    return;
                }

                Helper.ShowInfo("Значение показания сохранено.", "Успешная запись в базу данных");

                valueTextBox.Text = "Значение измерения";
                saveButton.Enabled = false;
            }
        }

        // Загрузка формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            sources = Source.Get(dbConnectionString);
            sourcesDropDown.DataSource = sources;

            sourcesDropDown.SelectedIndex = -1;
            sourcesDropDown.SelectedItem = null;

            sensorsDropDown.SelectedIndex = -1;
            sensorsDropDown.SelectedItem = null;
            sensorsDropDown.Enabled = false;

            parametersDropDown.SelectedIndex = -1;
            parametersDropDown.SelectedItem = null;
            parametersDropDown.Enabled = false;

            valueTextBox.Text = "Значение измерения";
            valueTextBox.Enabled = false;

            saveButton.Enabled = false;
        }

        // Выбор источника из списка
        private void sourcesDropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            Source selectedSource = (Source)senderComboBox.SelectedItem;

            sensorsDropDown.Enabled = false;

            parametersDropDown.Enabled = false;
            parametersDropDown.SelectedIndex = -1;
            parametersDropDown.SelectedItem = null;

            valueTextBox.Text = "Значение измерения";
            valueTextBox.Enabled = false;
            parameterUuid = null;

            saveButton.Enabled = false;

            if (selectedSource != null)
            {
                sensors = Source.GetSensors(dbConnectionString, selectedSource.sourceUuid);
                sensorsDropDown.DataSource = sensors.Where(x => x.state == "OK").ToList();
                sensorsDropDown.Enabled = true;
            }

            sensorsDropDown.SelectedIndex = -1;
            sensorsDropDown.SelectedItem = null;
        }

        // Выбор датчика из списка
        private void sensorsDropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            Sensor selectedSensor = (Sensor)senderComboBox.SelectedItem;

            parametersDropDown.Enabled = false;

            valueTextBox.Text = "Значение измерения";
            valueTextBox.Enabled = false;
            parameterUuid = null;

            saveButton.Enabled = false;

            if (selectedSensor != null)
            {
                parameters = Sensor.GetParameters(dbConnectionString, selectedSensor.sensorUuid);
                parametersDropDown.DataSource = parameters;
                parametersDropDown.Enabled = true;
            }

            parametersDropDown.SelectedIndex = -1;
            parametersDropDown.SelectedItem = null;
        }

        // Выбор параметра из списка
        private void parametersDropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            Parameter selectedParameter = (Parameter)senderComboBox.SelectedItem;

            valueTextBox.Text = "Значение измерения";
            valueTextBox.Enabled = false;

            saveButton.Enabled = false;

            if (selectedParameter != null)
            {
                parameterUuid = selectedParameter.parameterUuid;
                valueTextBox.Enabled = true;
            }
        }

        // Ввод текста в поле значения
        private void valueTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox senderTextBox = (TextBox)sender;
            string text = senderTextBox.Text;

            saveButton.Enabled = text.Length != 0;
        }
    }
}
