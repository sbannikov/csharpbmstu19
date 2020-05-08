using System;
using System.Collections.Generic;
using api.Models;
using Dapper;
namespace api.Repositories
{
    public class IndicatorRepository
    {
        private static String query = "SELECT * FROM `indicators`";
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
