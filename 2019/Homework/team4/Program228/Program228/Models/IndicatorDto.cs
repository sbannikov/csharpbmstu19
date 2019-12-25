using System;
namespace Program228.Models
{
    public class IndicatorDto
    {
        public String Source_uuid { get; set; }
        public String Pniv { get; set; }
        public String Sensor_uuid { get; set; }
        public String State { get; set; }
        public String Parameter_uuid { get; set; }
        public String Code { get; set; }
        public String Unit { get; set; }
        public String Type { get; set; }
        public String Timestamp_start { get; set; }
        public String Timestamp_end { get; set; }
        public String Value { get; set; }
        public String Last_changed { get; set; }
    }
}
