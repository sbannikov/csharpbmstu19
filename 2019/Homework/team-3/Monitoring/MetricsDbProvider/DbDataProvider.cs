using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using MetricsDbProvider.Models;
using MetricsSave.Interface;

namespace MetricsDbProvider
{
	public class DbDataProvider : IDbDataProvider
	{
		private readonly string _connectionString;
		private const string _dbPath = "default.sqlite";

		public DbDataProvider()
		{
			// TODO вынести в конфиг
			_connectionString = $"Data Source=${_dbPath};Version=3";

			if (!File.Exists(_dbPath))
			{
				SQLiteConnection.CreateFile(_dbPath);
				using (var connection = new SQLiteConnection(_connectionString))
				{
					connection.Open();
					var creationQuery =
						new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("CreateScripts.sql"))
							.ReadToEnd();

					var command = new SQLiteCommand(creationQuery, connection);
					command.ExecuteNonQuery();

					var fillQuery =
						new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("FillScripts.sql"))
							.ReadToEnd();

					command = new SQLiteCommand(fillQuery, connection);
					command.ExecuteNonQuery();
				}
			}
		}

		public void AddMark(Mark item)
		{
			using (var connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				var creationQuery = "insert into Mark values (@ValueUuid, @TimestampStart, @TimestampEnd, @Value, @MetricsId)";

				var command = new SQLiteCommand(creationQuery, connection);
				command.Parameters.Add(new SQLiteParameter("@ValueUuid", item.ValueUuid));
				command.Parameters.Add(new SQLiteParameter("@TimestampStart", item.TimestampStart));
				command.Parameters.Add(new SQLiteParameter("@TimestampEnd", item.TimestampEnd));
				command.Parameters.Add(new SQLiteParameter("@Value", item.Value));
				command.Parameters.Add(new SQLiteParameter("@MetricsId", item.MetricsId));

				command.ExecuteNonQuery();
			}
		}

		public IEnumerable<Source> GetSources()
		{
			using (var connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				var query = "select * from Source";

				var command = new SQLiteCommand(query, connection);
				var reader = command.ExecuteReader();
				var result = new List<Source>();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						result.Add(new Source() { SourceUuid = reader.GetString(0), Pinv = reader.GetString(1)});
					}
				}

				return result;
			}
		}

		public IEnumerable<Sensor> GetSensors(string sourceId)
		{
			using (var connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				var query = "select * from Sensor";

				var command = new SQLiteCommand(query, connection);
				var reader = command.ExecuteReader();
				var result = new List<Sensor>();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						result.Add(new Sensor() { SensorUuid = reader.GetString(0), State = (State)reader.GetInt16(1), SourceId = reader.GetString(2)});
					}
				}

				return result;
			}
		}

		public IEnumerable<Metrics> GetMetrics(string sensorId)
		{
			using (var connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				var query = "select * from Metrics";

				var command = new SQLiteCommand(query, connection);
				var reader = command.ExecuteReader();
				var result = new List<Metrics>();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						result.Add(new Metrics()
						{
							ParameterUuid = reader.GetString(0),
							Code = reader.GetString(1),
							Unit = reader.GetString(2),
							Type = reader.GetString(3),
							SensorId = reader.GetString(4)
						});
					}
				}

				return result;
			}
		}

		public IEnumerable<Mark> GetMarks()
		{
			using (var connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				var query = "select * from Metrics";

				var command = new SQLiteCommand(query, connection);
				var reader = command.ExecuteReader();
				var result = new List<Mark>();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						result.Add(new Mark()
						{
							ValueUuid = reader.GetString(0),
							TimestampStart = reader.GetInt64(1),
							TimestampEnd = reader.GetInt64(2),
							Value = reader.GetValue(3),
							MetricsId = reader.GetString(4)
						});
					}
				}

				return result;
			}
		}
	}
}
