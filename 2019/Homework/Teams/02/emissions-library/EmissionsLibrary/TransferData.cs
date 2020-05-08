using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;

namespace EmissionsLibrary
{
    [DataContract]
    [Serializable]
    public class TransferData
    {
        public TransferData() { }

        // Уникальный идентификатор значения показания
        [DataMember]
        public string valueUuid { get; set; }

        // Временные отметки усреднения значения показания
        [DataMember]
        public int timestampStart { get; set; }
        [DataMember]
        public int timestampEnd { get; set; }

        // Значение показания
        [DataMember]
        public string value { get; set; }

        // Название таблицы в БД
        public const string valuesTableName = "Results";

        // Уникальный идентификатор показания
        [DataMember]
        public string parameterUuid { get; set; }

        // Тип показания
        [DataMember]
        public string code { get; set; }

        // Единица измерения показания
        [DataMember]
        public string unit { get; set; }

        // Тип данных показания
        [DataMember]
        public string type { get; set; }

        // Название таблицы в БД
        public const string parametersTableName = "Parameters";

        // Уникальный идентификатор датчика
        [DataMember]
        public string sensorUuid { get; set; }

        // Состояние датчика {OK, ERROR, MAINTENANCE}
        [DataMember]
        public string state { get; set; }

        // Название таблицы в БД
        public const string sensorsTableName = "Sensors";

        // Уникальный идентификатор источника выбросов
        [DataMember]
        public string sourceUuid { get; set; }

        // Порядковый номер источника выбросов
        [DataMember]
        public int pniv { get; set; }

        // Название таблицы в БД
        public const string sourcesTableName = "Sources";

        // Получение всех данных по valueUuid
        public static TransferData Get(string connectionString, string valueUuid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery =
                    "select R.valueUuid, R.timestampStart, R.timestampEnd, R.value, " +
                    "P.parameterUuid, P.code, P.type, P.unit, " +
	                "Sns.sensorUuid, Sns.state, " +
	                "Src.sourceUuid, Src.pniv " +
                    $"from {valuesTableName} R " +
                    $"left outer join {parametersTableName} P " +
                    "on R.parameterUuid = P.parameterUuid " +
                    $"left outer join {sensorsTableName} Sns " +
                    "on P.sensorUuid = Sns.sensorUuid " +
                    $"left outer join {sourcesTableName} Src " +
                    "on Sns.sourceUuid = Src.sourceUuid " +
                    "where R.valueUuid = @valueUuid; ";

                return connection.QuerySingle<TransferData>(sqlQuery, new { valueUuid });
            }
        }
    }
}
