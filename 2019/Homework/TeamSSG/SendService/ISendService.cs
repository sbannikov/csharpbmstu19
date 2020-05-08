using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SendService
{
    [ServiceContract]
    public interface ISendService
    {

        [OperationContract]
        [WebGet(UriTemplate = "MeasuredValues")]
        void GetAndSendMeasuredValues();
    }

}
