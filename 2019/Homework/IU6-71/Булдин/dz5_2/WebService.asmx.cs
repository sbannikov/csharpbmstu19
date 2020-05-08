using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace dz5_2client_recieve
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Description = "5.2serviceapp", Namespace = XmlNS)]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        public const string XmlNS = "http://dz.52client_recieve.ru/";
        [WebMethod]
        public void SendData(string payload)//принимаем сериализованную строку
        {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Entity));

                using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(payload)))
                {
                    // десериализируем полученные данные, основываясь на entity             
                    Entity entity = serializer.ReadObject(stream) as Entity;
                    // добавляем данные в спиcок
                    ListEntity list = ListEntity.Sample;
                    list.AddEntity(entity);
                    // сообщаем, что передача успешна
                    //return result; 
                }
        }

    }
}
