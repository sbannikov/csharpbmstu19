using System;
using System.Data; // определяет классы, интерфейсы, делегаты, которые реализуют архитектуру ADO.NET
using System.Data.SqlClient; // пределяет функциональность провайдера для баз данных MS SQL Server
using System.Collections.Generic;

public struct Val
{
    public string source_uuid, pniv, sensor_uuid, state,
    parameter_uuid, code, unit, type, timestamp_start,
    timestamp_end, value, last_changed;
}

class Roma
{
    public static List<Val> GetDataFromDB()
    {
        List<Val> Vals = new List<Val>();
        string connectionString = "Server=db;Port=5432;Database=postgres;UserId=postgres;Password=postgres;";
        string queryString = "SELECT * FROM latestvals";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var oneValue = new Val();
                        oneValue.source_uuid = reader.GetString(0);
                        oneValue.pniv = reader.GetString(1);
                        oneValue.sensor_uuid = reader.GetString(2);
                        oneValue.state = reader.GetString(3);
                        oneValue.parameter_uuid = reader.GetString(4);
                        oneValue.code = reader.GetString(5);
                        oneValue.unit = reader.GetString(6);
                        oneValue.type = reader.GetString(7);
                        oneValue.timestamp_start = reader.GetString(8);
                        oneValue.timestamp_end = reader.GetString(9);
                        oneValue.value = reader.GetString(10);
                        oneValue.last_changed = reader.GetString(11);
                        Vals.Add(oneValue);
                    }
                }
            }
        }
        return Vals;
    }
    static void Main(string[] args)
    {

    }
}
