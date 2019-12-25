using System.Collections;
using System.Collections.Generic;
using MetricsDbProvider.Models;

namespace MetricsSave.Interface
{
	public interface IDbDataProvider
	{
		void AddMark(Mark item);

		IEnumerable<Source> GetSources();

		IEnumerable<Sensor> GetSensors(string sourceId);

		IEnumerable<Metrics> GetMetrics(string sensorId);

		IEnumerable<Mark> GetMarks();
	}
}
