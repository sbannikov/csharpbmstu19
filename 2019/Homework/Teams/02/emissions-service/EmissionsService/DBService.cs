using EmissionsLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace EmissionsService
{
    class DBService
    {
        private static readonly int pollInterval = Int32.Parse(ConfigurationManager.AppSettings["pollInterval"]) / 1000;
        private static readonly string dbConnectionString = ConfigurationManager.ConnectionStrings["emissionsDb"].ConnectionString;

        public static List<TransferData> GetData()
        {
            List<Value> values = Value.GetNew(dbConnectionString, pollInterval / 1000);

            if (values.Count == 0)
            {
                values = Value.GetLatest(dbConnectionString);
            }

            List<TransferData> allData = new List<TransferData>();

            foreach (Value val in values)
            {
                TransferData allValueData = TransferData.Get(dbConnectionString, val.valueUuid);

                allData.Add(allValueData);
            }

            return allData;
        }
    }
}
