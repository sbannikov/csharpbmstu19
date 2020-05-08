using SendService.DB.Model;
using SendService.XML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendService.XML
{
    public class DbToXmlAdapter
    {
        public static XmlModel Transform(List<DB.Model.Source> sources,
            List<DB.Model.Sensor> sensors,
            List<DB.Model.Parameter> parameters,
            List<Value> values)
        {
            XmlModel xml = new XmlModel
            {
                MeasuredValues = new List<MeasuredValue>()
            };
            values.ForEach(delegate (Value value)
            {
                var parameterDb = parameters.Where(parameter => parameter.ParameterUuid.Equals(value.ParameterId)).FirstOrDefault();
                var sensorDb = sensors.Where(sensor => sensor.SensorUuid.Equals(parameterDb.SensorId)).FirstOrDefault();
                var sourceDb = sources.Where(source => source.SourceUuid.Equals(sensorDb.SourceId)).FirstOrDefault();

                xml.MeasuredValues.Add(new MeasuredValue()
                    .WithUUID(value.ValueUuid)
                    .WithTimeStampStart(value.TimestampStart.ToString())
                    .WithTimeStampEnd(value.TimestampEnd.ToString())
                    .WithValue(value.ValueField)
                    .WithParameter(new Model.Parameter()
                        .WithUUID(parameterDb.ParameterUuid)
                        .WithCode(parameterDb.Code)
                        .WithUnit(parameterDb.Unit)
                        .WithType(parameterDb.Type)
                        .WithSensor(new Model.Sensor()
                            .WithUUID(sensorDb.SensorUuid)
                            .WithState(sensorDb.State)
                            .WithSource(new Model.Source()
                                .WithUUID(sourceDb.SourceUuid)
                                .WithPNIV(sourceDb.Pniv)
                            )
                        )
                        .WithDescription(parameterDb.Description)
                    )
                );
            });

            return xml;
        }
    }
}