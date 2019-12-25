using System;
using System.IO;
using System.Data.SQLite;

namespace Program228
{
    public class Database
    {
        public SQLiteConnection conn;

        public Database()
        {
            // "Server=db;Port=5432;Database=postgres;UserId=postgres;Password=postgres;";
            conn = new SQLiteConnection("Data Source=sqlite.db");
            if (!File.Exists("./sqlite.db"))
            {
                SQLiteConnection.CreateFile("./sqlite.db");
                Console.WriteLine("Database file created");
            }
        }

        public void OpenConnection()
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        public void CloseConnection()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }
}
