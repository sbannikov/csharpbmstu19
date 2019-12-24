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
           /* return "DATA SOURCE=//" + Properties.Settings.Default.dbHost + ":" +
                Properties.Settings.Default.dbPort + "/" + Properties.Settings.Default.dbScheme + ";" +
                "USER ID=" + Properties.Settings.Default.dbUser +
                "; password=" + Properties.Settings.Default.dbPassword + "; Pooling = False; ";*/
            return @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\smirn\source\repos\csharpbmstu\2019\Homework\TeamSSG\SendService\App_Data\MeasuredValues.mdf; Integrated Security = True";
        }

       /* public OracleConnection GetConnection()
        {
            OracleConnection conn = new OracleConnection(GetConnectionStringFromConfig());
            conn.Open();
            Connection = conn;
            return conn;
        }*/

        public void Dispose()
        {
            Connection.Close();
        }

    }
}