using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EmissionsLibrary
{
    public class Source
    {
        // Уникальный идентификатор источника выбросов
        public string sourceUuid { get; set; }

        // Порядковый номер источника выбросов
        public int pniv { get; set; }

        // Название таблицы в БД
        public const string tableName = "Sources";

        public Source()
        {
            sourceUuid = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return "Источник №" + pniv.ToString();
        }

        // Получение списка всех истоников выбросов из базы данных
        public static List<Source> Get(string connectionString)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"SELECT * FROM {tableName};";
                return connection.Query<Source>(sqlQuery).ToList();
            }
        }

        // Получение источника по его sourceUuid
        public static Source Get(string connectionString, string uuid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"SELECT * FROM {tableName} WHERE sourceUuid = @sourceUuid;";
                return connection.QuerySingle<Source>(sqlQuery, new { sourceUuid = uuid });
            }
        }

        // Получение списка датчиков, расположенных на данном источнике выбросов
        public static List<Sensor> GetSensors(string connectionString, string sourceUuid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"SELECT * FROM {Sensor.tableName} Snr WHERE Snr.sourceUuid = @sourceUuid;";
                return connection.Query<Sensor>(sqlQuery, new { sourceUuid }).ToList();
            }
        }

        // Сохранение нового значения в базу данных
        public static void Create(string connectionString, Source source)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"INSERT INTO {tableName} (sourceUuid, pniv) VALUES (@sourceUuid, @pniv);";

                connection.Execute(sqlQuery, source);
            }
        }
    }
}
