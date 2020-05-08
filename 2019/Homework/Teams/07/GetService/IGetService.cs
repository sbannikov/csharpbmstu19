using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GetService
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IGetService
    {
        [WebInvoke(Method = "POST", UriTemplate = "MeasuredValues",
            RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        void PostMeasuredValues(XmlModel measuredValues);

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "MeasuredValues")]
        XmlModel GetMeasuredValues();
    }

}
