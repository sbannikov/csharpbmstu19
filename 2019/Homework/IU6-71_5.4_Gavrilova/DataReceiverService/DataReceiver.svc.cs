using EntityClassLibrary;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DataReceiverService
{
    public class DataReceiver : IDataReceiver
    {
        public string ReceiveData(String payload)
        {
            System.Diagnostics.Debug.WriteLine(payload);

            payload = payload.Trim();
            
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Entity));

            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(payload)))
            {
                // Convert the stream buffer to an object with serializer.              
                Entity entity = serializer.ReadObject(stream) as Entity;
                                
                // Adding the indication to the list stored in Singleton
                Singleton singleton = Singleton.Instance;
                singleton.AddEntity(entity);

                // To confirm that service received and parsed the indication
                string result = "Indication " + entity.parameter_uuid + " is received";
                System.Diagnostics.Debug.WriteLine(result);
                return result;
            }
        }
    }
}
