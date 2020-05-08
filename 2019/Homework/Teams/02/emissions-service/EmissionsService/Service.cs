using System;
using System.Configuration;
using System.ServiceProcess;
using System.Timers;

namespace EmissionsService
{
    public partial class Service : ServiceBase
    {
        private readonly Timer timer = new Timer();
        private readonly int pollInterval = Int32.Parse(ConfigurationManager.AppSettings["pollInterval"]);

        public Service()
        {
            InitializeComponent();
        }

        // Для запуска в качестве консольного приложения
        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }

        protected override void OnStart(string[] args)
        {
            timer.Interval = pollInterval;
            timer.Elapsed += new ElapsedEventHandler(this.ProcessData);
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        // Получение и отправка данных
        protected void ProcessData(object sender, ElapsedEventArgs args)
        {
            TransmitionService.SendData(DBService.GetData());            
        }
    }
}
