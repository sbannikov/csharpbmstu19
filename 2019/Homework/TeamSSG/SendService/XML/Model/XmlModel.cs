using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SendService.XML.Model
{
    [XmlRoot("MeasuredValues")]
    public class XmlModel
    {
        [XmlElement("MeasuredValue")]
        public List<MeasuredValue> MeasuredValues { get; set; }

        public XmlModel WithMeasuredValues(List<MeasuredValue> measuredValues)
        {
            MeasuredValues = measuredValues;
            return this;
        }
    }

    public class MeasuredValue
    {
        [XmlElement]
        public string UUID { get; set; }

        public MeasuredValue WithUUID(string uuid)
        {
            UUID = uuid;
            return this;
        }

        [XmlElement]
        public string TimeStampStart { get; set; }
        public MeasuredValue WithTimeStampStart(string timeStampStart)
        {
            TimeStampStart = timeStampStart;
            return this;
        }

        [XmlElement]
        public string TimeStampEnd { get; set; }
        public MeasuredValue WithTimeStampEnd(string timeStampEnd)
        {
            TimeStampEnd = timeStampEnd;
            return this;
        }

        [XmlElement]
        public string Value { get; set; }

        public MeasuredValue WithValue(string value)
        {
            Value = value;
            return this;
        }

        [XmlElement]
        public Parameter Parameter { get; set; }

        public MeasuredValue WithParameter(Parameter parameter)
        {
            Parameter = parameter;
            return this;
        }
    }

    public class Parameter
    {
        [XmlElement]
        public string UUID { get; set; }

        public Parameter WithUUID(string uuid)
        {
            UUID = uuid;
            return this;
        }

        [XmlElement]
        public string Code { get; set; }

        public Parameter WithCode(string code)
        {
            Code = code;
            return this;
        }

        [XmlElement]
        public string Unit { get; set; }

        public Parameter WithUnit(string unit)
        {
            Unit = unit;
            return this;
        }

        [XmlElement]
        public string Type { get; set; }

        public Parameter WithType(string type)
        {
            Type = type;
            return this;
        }

        [XmlElement]
        public Sensor Sensor { get; set; }

        public Parameter WithSensor(Sensor sensor)
        {
            Sensor = sensor;
            return this;
        }

        [XmlElement]
        public string Description { get; set; }

        public Parameter WithDescription(string description)
        {
            Description = description;
            return this;
        }
    }

    public class Sensor
    {
        [XmlElement]
        public string UUID { get; set; }

        public Sensor WithUUID(string uuid)
        {
            UUID = uuid;
            return this;
        }

        [XmlElement]
        public string State { get; set; }

        public Sensor WithState(string state)
        {
            State = state;
            return this;
        }

        [XmlElement]
        public Source Source { get; set; }

        public Sensor WithSource(Source source)
        {
            Source = source;
            return this;
        }


    }

    public class Source
    {
        [XmlElement]
        public string UUID { get; set; }

        public Source WithUUID(string uuid)
        {
            UUID = uuid;
            return this;
        }

        [XmlElement]
        public int PNIV { get; set; }

        public Source WithPNIV(int pniv)
        {
            PNIV = pniv;
            return this;
        }
    }
}