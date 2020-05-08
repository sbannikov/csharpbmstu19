using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Нэймспэйс, отвечающий за модели для сериализации данных из БД.
/// </summary>
namespace SendService.DB.Model
{
    public class Source
    {
        [Key]
        public String SourceUuid { get; set; }
        public int Pniv { get; set; }
    }

    public class Sensor
    {
        [Key]
        public String SensorUuid { get; set; }
        public String State { get; set; }
        public String SourceId { get; set; }
    }

    public class Parameter
    {
        [Key]
        public String ParameterUuid { get; set; }
        public String Code { get; set; }
        public String Unit { get; set; }
        public String Type { get; set; }
        public String SensorId { get; set; }
        public String Description { get; set; }

    }

    [Serializable]
    public class Value
    {
        [Key]
        public String ValueUuid { get; set; }
        public System.DateTime TimestampStart { get; set; }
        public System.DateTime TimestampEnd { get; set; }
        public String ValueField { get; set; }

        public String ParameterId { get; set; }
    }
}