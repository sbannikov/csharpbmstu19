using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EmissionsLibrary
{
    public class Sensor
    {
        // Уникальный идентификатор датчика
        public string sensorUuid { get; set; }

        // Состояние датчика {OK, ERROR, MAINTENANCE}
        public string state { get; set; }

        // Уникальный идентификатор источника выбросов, на котором расположен данный сенсор
        public string sourceUuid { get; set; }

        // Название таблицы в БД
        public const string tableName = "Sensors";

        public Sensor()
        {
            sensorUuid = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return "Датчик " + sensorUuid;
        }

        // Получение списка всех датчиков из базы данных
        public static List<Sensor> Get(string connectionString)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"SELECT * FROM {tableName};";
                return connection.Query<Sensor>(sqlQuery).ToList();
            }
        }

        // Получение датчика по его sensorUuid
        public static Sensor Get(string connectionString, string uuid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"SELECT * FROM {tableName} WHERE sensorUuid = @sensorUuid;";
                return connection.QuerySingle<Sensor>(sqlQuery, new { sensorUuid = uuid });
            }
        }

        // Получение списка параметров, измеряемых одним датчиком
        public static List<Parameter> GetParameters(string connectionString, string sensorUuid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"SELECT * FROM {Parameter.tableName} Param WHERE Param.sensorUuid = @sensorUuid;";
                return connection.Query<Parameter>(sqlQuery, new { sensorUuid }).ToList();
            }
        }

        // Сохранение нового датчика в базу данных
        public static void Create(string connectionString, Sensor sensor)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"INSERT INTO {tableName} (sensorUuid, state, sourceUuid)" +
                    " VALUES (@sensorUuid, @state, @sourceUuid);";

                connection.Execute(sqlQuery, sensor);
            }
        }
    }
}
