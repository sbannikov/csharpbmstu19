using SendService.DB;
using SendService.DB.Model;
using SendService.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SendService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class SendService : ISendService
    {
        public void GetAndSendMeasuredValues()
        {
            var dbSerializer = new DBSerializer();
            List<Value> values = dbSerializer.GetValues();
            List<Parameter> parameters = dbSerializer.GetParameters();
            List<Sensor> sensors = dbSerializer.GetSensors();
            List<Source> sources = dbSerializer.GetSources();

            var xml = DbToXmlAdapter.Transform(sources, sensors, parameters, values);

            XmlSerializer formatter = new XmlSerializer(typeof(XML.Model.XmlModel));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            StringWriter sw = new StringWriter();
            using (XmlWriter xw = XmlWriter.Create(sw, settings))
            {
                formatter.Serialize(xw, xml, namespaces);
            }

            sw.Close();

            var postData = sw.ToString();

            ASCIIEncoding encoding = new ASCIIEncoding();

            byte[] data = encoding.GetBytes(postData);
            string url = Properties.Settings.Default.getServiceUrl + "/GetService.svc/MeasuredValues";

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "POST";
            webrequest.ContentType = "application/xml";
            webrequest.ContentLength = data.Length;
            Stream newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            webrequest.GetResponse();

        }
    }
}
