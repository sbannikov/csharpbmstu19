using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
namespace SenderService
{
	class Program
	{
		static void Main(string[] args)
		{
			var service = new Service();
			ServiceBase.Run(service);
		}
	}
}
