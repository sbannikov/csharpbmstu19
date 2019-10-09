using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SampeAdoNet
{
    public class Database : IDisposable
    {/// <summary>
     /// Соединение с сервером БД
     /// </summary>
        private SqlConnection conn;

        public Database()
        {
            // Создание соединения
            conn = new SqlConnection()
            {
                ConnectionString = @"data source=.\SQLEXPRESS;initial catalog=BMSTU;integrated security=True;MultipleActiveResultSets=True;App=SampleAdoNet"
            };
        }

        public void WorkAdoNet(string group)
        {
            // Открытие соединения
            conn.Open();

            // Команда
            SqlCommand cmd = conn.CreateCommand();

            // SQL-запрос к базе данных
            cmd.CommandText = "SELECT Family, Name FROM Students WHERE [Group] = @group ORDER BY Family";
            cmd.Parameters.AddWithValue("group", group);

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Console.WriteLine("{0} {1}", rdr.GetString(0), rdr.GetString(1));
                }
            }

            cmd.CommandText = "SELECT COUNT(*) FROM Students WHERE [Group] = @group";
            object result = cmd.ExecuteScalar();
            Console.WriteLine(result);

            cmd.CommandText = "INSERT INTO Students (Name, Family, [Group], FileNumber) VALUES (@name, @family, @group, @file)";
            cmd.Parameters.AddWithValue("name", "Hans");
            cmd.Parameters.AddWithValue("family", "Gimmler");
            cmd.Parameters.AddWithValue("file", "DDR");

            int count = cmd.ExecuteNonQuery();
            Console.WriteLine(count);
        }

        public void WorkDapper(string group)
        {
            // Открытие соединения
            conn.Open();

            string sql = "SELECT * FROM Students WHERE [Group] = @group ORDER BY Family";
            foreach (var student in conn.Query<Student>(sql, new { Group = group }))
            {
                Console.WriteLine($"{student.Family} {student.Name}");
            }

            sql = "INSERT INTO Students(Name, Family, [Group], FileNumber) VALUES(@Name, @Family, @Group, @File)";
            conn.Query(sql, new { Name = "Klaus", Family = "Mueller", Group = group, File = "DDR" });

            sql = "SELECT COUNT(*) FROM Students WHERE [Group] = @Group";
            var result = conn.QueryFirst(sql, new { Group = group });         
            Console.WriteLine(result);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    conn.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Database() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
