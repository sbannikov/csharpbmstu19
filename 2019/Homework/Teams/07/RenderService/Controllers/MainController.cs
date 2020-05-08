using RenderService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace RenderService.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {

            string url = Properties.Settings.Default.getServiceUrl + "/GetService.svc/MeasuredValues";

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/xml";



            var response = (HttpWebResponse)webrequest.GetResponse();

            Stream responseStream = response.GetResponseStream();

            StreamReader sr = new StreamReader(responseStream);

            XmlReaderSettings settings = new XmlReaderSettings();

            XmlReader xr = XmlReader.Create(sr, settings);

            XmlSerializer formatter = new XmlSerializer(typeof(XmlModel));

            try
            {
                return View(((XmlModel)formatter.Deserialize(xr)).MeasuredValues);
            }
            catch
            {
                return View(new List<MeasuredValue>()); 
            }
        }
    }
}