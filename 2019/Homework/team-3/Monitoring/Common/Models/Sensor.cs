namespace MetricsDbProvider.Models
{
	public class Sensor
	{
		public string SensorUuid { get; set; }

		public State State { get; set; }

		public string SourceId { get; set; }
	}
}
