namespace Dz
{
	using Core.Code;
	using Core.Model;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;

	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				var dbDataProvider = DbDataProviderFactory.Instance.CreateDbProvider();

				var marks = JsonConvert.DeserializeObject<
					IEnumerable<Mark>
					>(
						File.ReadAllText("mock.json")
					);

				foreach (var mark in marks)
				{
					dbDataProvider.AddMark(mark);
				}


				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Данные показателей успешно загружены (источник: mock.json)");
				Console.ResetColor();

				Console.WriteLine("Чтение показателей из базы (источник: db.sqlite");

				foreach (var mark in dbDataProvider.GetMarks())
				{
					Console.WriteLine(
						string.Join('\t', "ValueUuid: {0}", "TimestampStart: {1}", "TimestampEnd: {2}", "Value: {3}", "ParameterUuid"),
						mark.ValueUuid,
						mark.TimestampStart,
						mark.TimestampEnd,
						mark.Value,
						mark.MetricsId
					);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			finally
			{
				Console.ReadKey();
			}
		}
	}
}
