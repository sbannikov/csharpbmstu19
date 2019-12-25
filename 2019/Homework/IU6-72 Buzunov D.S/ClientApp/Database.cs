using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Utility;

namespace ClientApp{

    public class Database: IDisposable{
       
        ///<summary>
        ///Подлючение к БД
        ///</summary>
        private SqlConnection conn;
        ///<summary>
        ///Команда для БД
        ///</summary>
        private SqlCommand comm;
        ///<summary>
        /// Чтение настроек подключения из файла DBSettings.cfg
        ///</summary>
        private string[] parceSettings(){
            string setFile = @"./DBSettings.cfg";
            if (File.Exists(setFile)){
                string[] lines = File.ReadAllText(setFile).Split("/n");
            }
        }

        ///<summary>
        /// Инициализация класса так же выполняет скрипт по созданию таблиц, если они не созданы до этого
        ///</summary>
        public Database(){
            string[] connParam = parceSettings();
            conn = new SqlConnection(){
                ConnectionString = "Data Source="+connParam[1]+";Initial Catalog="+connParam[2]+ ";User ID=" + connParam[3] + "Password=" + connParam[4] + ";App=" + connParam[5] + ";"
            };
            conn.open();
            string DBMake = File.ReadAllText(@"./DBScheme.sql");
            comm = new SqlCommand(DBMake, conn);
            comm.ExecuteNonQuery();
        }

        ///<summary>
        /// Закрытие соединения с БД. Вызвать перед закрытием программы
        ///</summary>
        public CloseConn(){
            comm.Close();
        }

        ///<summary>
        ///Загрузка объекта в БД
        ///</summary>
        /// <param name="src"></param>
        public SendToDB(Source src){
            string comand = @"INSERT INTO Sources(source_uuid, pniv) 
                              VALUES ('";
            comand += src.Source_uuid;
            comand += @"' , ";
            comand += src.Pniv.ToString() + @");";
            comm = new SqlCommand(comand, conn);
            comm.ExecuteNonQuery();
        }

        public SendToDB(Sensor sens){
            string comand = @"INSERT INTO Sensors(sensor_uuid, parent_source_uuid, state)
            VALUES ('";
            comand += sens.Sensor_uuid + @"' , '";
            comand += sens.Parent_source_uuid + @"' , '";
            comand += sens.State + @"');";
            comm = new SqlCommand(comand, conn);
            comm.ExecuteNonQuery();
        }

        public SendToDB(Parameter param){
            string comand = @"INSERT INTO Parameters(parameter_uuid, parent_sensor_uuid, code, unit, type) 
            VALUES('";
            comand += param.Parameter_uuid + @"' , '";
            comand += param.Parent_sensor_uuid + @"' , '";
            comand += param.Code + @"' , '";
            comand += param.Unit + @"' , '";
            comand += param.Type + @"' , '";
            comm = new SqlCommand(comand, conn);
            comm.ExecuteNonQuery();
        }

        public SendToDB(Value val){
            string comand = @"INSERT INTO Vals(value_uuid, parent_parameter_uuid, timestamp_start, timestamp_end, value, last_changed) 
            VALUES('";
            comand += val.Value_uuid + @"' , '";
            comand += val.Parent_parameter_uuid + @"' , ";
            comand += val.Timestamp_start.ToString() + @" , ";
            comand += val.Timestamp_end.ToString() + @" , '";
            comand += val.Data.ToString() + @"' , ";
            comand += @"CURRENT_TIMESTAMP);";
            comm = new SqlCommand(comand, conn);
            comm.ExecuteNonQuery();
        }
    }
}