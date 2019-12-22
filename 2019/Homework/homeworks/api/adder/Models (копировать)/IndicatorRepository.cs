using System;
using System.Collections.Generic;
using System.Data.SQLite;
namespace api.Models
{
    public class SensorRepository
    {
        public SensorRepository() { }

        public List<SensorModel> GetSensors()
        {
            List<SensorModel> users = new List<SensorModel>();
            string query = "SELECT `sensor_uuid` FROM `sensors`";
            Database databaseObject = new Database();
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.conn);
            SQLiteDataReader result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    SourceData.Add(new string(result["pniv"].ToString()));
                }

                ViewData["source_data"] = SourceData;
            }

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                users = db.Query<User>("SELECT * FROM Users").ToList();
            }
            return users;
        }
    }
}
