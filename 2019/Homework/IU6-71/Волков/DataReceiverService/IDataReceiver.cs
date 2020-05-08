using System;
using System.ServiceModel;
using System.IO;
using EntityClassLibrary;

namespace DataReceiverService
{
    [ServiceContract]
    public interface IDataReceiver
    {
        [OperationContract]
        Entity getjson ();
    }

}


