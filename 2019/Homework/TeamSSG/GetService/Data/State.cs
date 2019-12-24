using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace GetService
{
    public enum State
    {
        [XmlEnum]
        OK, 
        [XmlEnum]
        ERROR,
        [XmlEnum]
        MAINTENANCE
    }
}