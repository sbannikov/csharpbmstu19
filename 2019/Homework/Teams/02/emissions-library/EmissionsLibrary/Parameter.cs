using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EmissionsLibrary
{
    public class Parameter
    {
        // Уникальный идентификатор показания
        public string parameterUuid { get; set; }

        // Тип показания
        public string code { get; set; }

        // Единица измерения показания
        public string unit { get; set; }

        // Тип данных показания
        public string type { get; set; }

        // Уникальный идентификатор сенсора
        public string sensorUuid { get; set; }

        // Название таблицы в БД
        public const string tableName = "Parameters";

        public Parameter()
        {
            parameterUuid = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return "Показатель " + code;
        }

        // Получение списка всех параметров из базы данных
        public static List<Parameter> Get(string connectionString)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"SELECT * FROM {tableName};";
                return connection.Query<Parameter>(sqlQuery).ToList();
            }
        }

        // Получение параметра по его parameterUuid
        public static Parameter Get(string connectionString, string uuid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"SELECT * FROM {tableName} WHERE parameterUuid = @parameterUuid;";
                return connection.QuerySingle<Parameter>(sqlQuery, new { parameterUuid = uuid });
            }
        }

        // Получение списка значений для одного параметра
        public static List<Value> GetValues(string connectionString, string parameterUuid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"SELECT * FROM {Value.tableName} Val WHERE Val.parameterUuid = @parameterUuid;";
                return connection.Query<Value>(sqlQuery, new { parameterUuid }).ToList();
            }
        } 

        // Сохранение нового параметра в базу данных
        public static void Create(string connectionString, Parameter parameter)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"INSERT INTO {tableName} (parameterUuid, code, unit, type, sensorUuid)" +
                    " VALUES (@parameterUuid, @code, @unit, @type, @sensorUuid);";

                connection.Execute(sqlQuery, parameter);
            }
        }
    }
}
