using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;

namespace GetService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class GetService : IGetService
    {
        private XmlModel XmlModel;

        public void PostMeasuredValues(XmlModel measuredValues)
        {
            XmlModel = measuredValues;
        }

        public XmlModel GetMeasuredValues()
        {
            return XmlModel;
        }
    }
}
