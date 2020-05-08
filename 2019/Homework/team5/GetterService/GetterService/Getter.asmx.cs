using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace GetterService
{
    public class Getter : IDataGetter
    {

        [WebMethod]
        public string GetData(String payload)
        {
            System.Diagnostics.Debug.WriteLine(payload);

            payload = payload.Trim();

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Entity));

            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(payload)))
            {            
                Entity entity = serializer.ReadObject(stream) as Entity;
                Singleton singleton = Singleton.Instance;
                singleton.AddEntity(entity);

                string result = "Измерение " + entity.parameter_uuid + " получено";
                System.Diagnostics.Debug.WriteLine(result);
                return result;
            }
        }
    }
}
