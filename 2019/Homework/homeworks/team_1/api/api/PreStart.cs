using System;
using System.IO;
using System.Data.SQLite;

namespace api
{
    public class PreStart
    {
        Database databaseObject = new Database();

        public PreStart()
        {
            Console.WriteLine("Pre-initializing database");
        }

        public void CreateTables()
        {
            string[] queries;
            queries = new String[5]
            {
                "CREATE TABLE `sources` (`source_id` TEXT NOT NULL UNIQUE, `pniv` INTEGER NOT NULL UNIQUE, PRIMARY KEY(`source_id`))",
                "CREATE TABLE `sensors` (`sensor_uuid` TEXT NOT NULL UNIQUE, `state` TEXT NOT NULL, PRIMARY KEY(`sensor_uuid`))",
                "CREATE TABLE `parameteres` (`parameter_uuid` TEXT NOT NULL UNIQUE, `code` TEXT NOT NULL, `unit` TEXT NOT NULL, `type` TEXT NOT NULL, PRIMARY KEY(`parameter_uuid`))",
                "CREATE TABLE `values` (`value_uuid` TEXT NOT NULL UNIQUE, `timestamp_start`	INTEGER NOT NULL, `timestamp_end` INTEGER NOT NULL, `value` TEXT NOT NULL, PRIMARY KEY(`value_uuid`))",
                "CREATE TABLE `indicators` (`code` TEXT NOT NULL, `unit` TEXT NOT NULL, `type` TEXT NOT NULL, `value` TEXT NOT NULL)"
            };

            SQLiteCommand command;

            databaseObject.OpenConnection();
            foreach (string query in queries)
            {
                command = new SQLiteCommand(query, databaseObject.conn);
                command.ExecuteNonQuery();
            }
            databaseObject.CloseConnection();
        }

        public void GenerateData()
        {
            databaseObject.OpenConnection();


            // TABLE `Sources`
            for (int i = 0; i < 10; i++)
            {
                string query = "INSERT INTO `sources` (`source_id`, `pniv`) VALUES (@SourceID, @Pniv)";
                SQLiteCommand command = new SQLiteCommand(query, databaseObject.conn);

                Random rand = new Random();
                command.Parameters.AddWithValue("@SourceID", System.Guid.NewGuid().ToString());
                command.Parameters.AddWithValue("@Pniv", i + rand.Next(1000));
                command.ExecuteNonQuery();
            }


            // TABLE `Sensors`
            for (int i = 0; i < 10; i++)
            {
                string query = "INSERT INTO `sensors` (`sensor_uuid`, `state`) VALUES (@SensorID, @State)";
                SQLiteCommand command = new SQLiteCommand(query, databaseObject.conn);

                string[] states;
                states = new String[3] { "OK", "ERROR", "MAINENANCE" };
                Random rand = new Random();
                command.Parameters.AddWithValue("@SensorID", System.Guid.NewGuid().ToString());
                command.Parameters.AddWithValue("@State", states[rand.Next(states.Length)]);
                command.ExecuteNonQuery();
            }


            // TABLE `Parameteres`
            for (int i = 0; i < 10; i++)
            {
                string query = "INSERT INTO `parameteres` (`parameter_uuid`, `code`, `unit`, `type`) VALUES (@ParamID, @Code, @Unit, @Type)";
                SQLiteCommand command = new SQLiteCommand(query, databaseObject.conn);

                string[] codes;
                codes = new String[10] { "H2SkgPerHour", "SO2kgPerHour", "SuspendedParticulateskgPerHour", "NOxkgPerHour", "COxFuelkgPerHour", "COxkgPerHour", "HFkgPerHour", "HClkgPerHour", "NH3kgPerHour", "ElectronicSealState" };
                Random rand = new Random();
                command.Parameters.AddWithValue("@ParamID", System.Guid.NewGuid().ToString());
                command.Parameters.AddWithValue("@Code", codes[rand.Next(codes.Length)]);
                command.Parameters.AddWithValue("@Unit", "kgPH");
                command.Parameters.AddWithValue("@Type", rand.Next(100));
                command.ExecuteNonQuery();
            }


            // TABLE `Values`
            for (int i = 0; i < 10; i++)
            {
                string query = "INSERT INTO `values` (`value_uuid`, `timestamp_start`, `timestamp_end`, `value`) VALUES (@ValueID, @TimeStart, @TimeEnd, @Value)";
                SQLiteCommand command = new SQLiteCommand(query, databaseObject.conn);

                Random rand = new Random();
                Int32 unixTimestampNow = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                command.Parameters.AddWithValue("@ValueID", System.Guid.NewGuid().ToString());
                command.Parameters.AddWithValue("@TimeStart", unixTimestampNow);
                command.Parameters.AddWithValue("@TimeEnd", unixTimestampNow + rand.Next(1000));
                command.Parameters.AddWithValue("@Value", i + rand.Next(1000));
                command.ExecuteNonQuery();
            }

            databaseObject.CloseConnection();
        }
    }
}




