namespace Core.Interface
{
	using Core.Model;
	using System.Collections.Generic;

	public interface IDbDataProvider
	{
		void AddMark(Mark item);

		IEnumerable<Source> GetSources();

		IEnumerable<Sensor> GetSensors(string sourceId);

		IEnumerable<Metrics> GetMetrics(string sensorId);

		IEnumerable<Mark> GetMarks();
	}
}
