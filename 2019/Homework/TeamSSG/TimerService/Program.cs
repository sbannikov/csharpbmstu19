using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerService
{
    class Program
    {
        static void SendRequest(object state)
        {
            string url = Properties.Settings.Default.sendServiceUrl + "/SendService.svc/MeasuredValues";
            Console.WriteLine("\nSending request to\n" + url + "...");

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.GetResponse();
        }

        private static void SetTimer()
        {
            new Timer(new TimerCallback(SendRequest), null, 0, Properties.Settings.Default.pollingInterval);
           
        }
        static void Main(string[] args)
        {
            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();

            Console.WriteLine("Terminating the application...");
        }
    }
}
