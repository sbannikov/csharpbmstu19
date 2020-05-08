using System;
using System.IO;
using System.Data.SQLite;

namespace api
{
    public class Database
    {
        public SQLiteConnection conn;

        public Database()
        {
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
