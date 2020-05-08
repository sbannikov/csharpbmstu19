using EmissionsLibrary;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace EmissionsInput
{
    public static class Helper
    {
        public static string[] States = new string[3] { "OK", "ERROR", "MAINTENANCE" };

        public static string ConnectionStringValue(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static List<Parameter> GenerateParameters(string sensorUuid)
        {
            var parameters = new List<Parameter>();

            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "H2SkgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "SO2kgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "SuspendedParticulateskgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "NOxkgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "COxFuelkgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "COxkgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "HFkgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "HClkgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "NH3kgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "ElectronicSealState", type = "string", unit = "State" });

            return parameters;
        }

        public static DialogResult ShowParseError(string text)
        {
            return MessageBox.Show(
                text,
                "Неверный формат данных",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static DialogResult ShowDbError(string caption)
        {
            return MessageBox.Show(
                "Проверьте конфигурацию подключения к базе данных.",
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static DialogResult ShowInfo(string text, string caption)
        {
            return MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
