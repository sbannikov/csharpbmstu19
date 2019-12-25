using System;
using System.Collections.Generic;
using Program228.Models;
using Dapper;
namespace Program228.Repositories
{
    public class IndicatorRepository
    {
        private static String query = "SELECT * FROM `latestvals`";
        private Database databaseObject;

        public IndicatorRepository() {
            databaseObject = new Database();
        }

        public List<IndicatorDto> GetValues() {
            
            databaseObject.OpenConnection();
            List<IndicatorDto> indicatotDto = databaseObject.conn.Query<IndicatorDto>(query).AsList();
            databaseObject.CloseConnection();
            return indicatotDto;
        }
    }
}
