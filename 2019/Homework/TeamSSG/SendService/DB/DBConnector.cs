using Oracle.ManagedDataAccess.Client;
using System;
using System.Data.SqlClient;

namespace SendService.DB
{
    /// <summary>
    /// Класс, отвечающий за подключение к БД.
    /// Параметры прописываются в конфигурации к проекту.
    /// </summary>
    public class DBConnector : IDisposable
    {
        public DBConnector() { }

        private SqlConnection Connection;

        public static String GetConnectionStringFromConfig()
        {
            return @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\smirn\source\repos\csharpbmstu\2019\Homework\TeamSSG\SendService\App_Data\MeasuredValues.mdf; Integrated Security = True";
        }


        public void Dispose()
        {
            Connection.Close();
        }

    }
}