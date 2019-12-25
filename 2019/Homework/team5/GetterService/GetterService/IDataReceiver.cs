using System;
using System.ServiceModel;

namespace GetterService
{
    [ServiceContract]
    public interface IDataGetter
    {
        [OperationContract]
        string GetData(String incomingJson);
    }

}