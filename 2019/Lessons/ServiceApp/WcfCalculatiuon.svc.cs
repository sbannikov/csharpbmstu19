using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WcfCalculatiuon" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WcfCalculatiuon.svc or WcfCalculatiuon.svc.cs at the Solution Explorer and start debugging.
    public class WcfCalculatiuon : IWcfCalculatiuon
    {
        public string DoWork()
        {
            return "Работа сделана";
        }
    }
}
