namespace SenderService
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Diagnostics;
	using System.Linq;
	using System.ServiceProcess;
	using System.Text;
	using System.Threading.Tasks;
	using System.Timers;
	using System.Configuration;
	using MetricsDbProvider;

	public class Service : ServiceBase
	{
		private readonly Timer _timer = new Timer();
		private readonly long _pollInterval = Int32.Parse(ConfigurationManager.AppSettings["pollInterval"]);

		public Service()
		{
			_timer.Interval = _pollInterval;
			_timer.Elapsed += new ElapsedEventHandler(this.ProcessData);
			_timer.Start();
		}

		protected override void OnStart(string[] args)
		{
			
		}

		protected override void OnStop()
		{
			_timer.Stop();
		}
		
		protected void ProcessData(object sender, ElapsedEventArgs args)
		{
			_timer.Enabled = false;
			SenderService.SendData(DbDataProvider.GetMarks());
			_timer.Enabled = true;
		}
	}
}