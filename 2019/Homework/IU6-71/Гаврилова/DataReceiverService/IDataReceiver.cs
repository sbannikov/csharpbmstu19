using System;
using System.ServiceModel;

namespace DataReceiverService
{
    [ServiceContract]
    public interface IDataReceiver
    {
        [OperationContract]
        string ReceiveData(String incomingJson);
    }

}
