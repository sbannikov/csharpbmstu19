using Dapper;
using Oracle.ManagedDataAccess.Client;
using SendService.DB.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SendService.DB
{
    /// <summary>
    /// Класс для получение сериализованных данных из БД.
    /// </summary>
    public class DBSerializer
    {

        private SqlConnection Connection = new SqlConnection(DBConnector.GetConnectionStringFromConfig());
        public DBSerializer(DBConnector connector)
        {
           // Connection = connector.GetConnection();
        }

        public List<Source> GetSources()
        {
            var query = @"select source_uuid as SourceUuid, pniv as Pniv from source";
            return Connection.Query<Source>(query).ToList();
        }

        public List<Sensor> GetSensors()
        {
            var query = @"select sensor_uuid as SensorUuid, state as State, source_id as SourceId from sensor";
            return Connection.Query<Sensor>(query).ToList();
        }

        public List<Parameter> GetParameters()
        {
            var query = @"select parameter_uuid as ParameterUuid, code as Code, unit as Unit, type as Type, sensor_id as SensorId, description as Description from parameter";
            return Connection.Query<Parameter>(query).ToList();
        }

        public List<Value> GetValues()
        { 
            var query = "select value_uuid as ValueUuid, TIMESTAMP_START as TimestampStart, TIMESTAMP_END as TimestampEnd, \"VALUE\".VALUE as ValueField, PARAMETER_ID as ParameterId from value";
           
            return Connection.Query<Value>(query).ToList();
        }
    }
}