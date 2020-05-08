using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using MetricsDbProvider.Models;

namespace SenderService
{
	public class SenderService 
	{
		public static void SendData(IEnumerable<Mark> transmissionDataList)
		{
			var serializer = new XmlSerializer(typeof(IEnumerable<Mark>));
			using (Stream ms = new MemoryStream())
			{
				serializer.Serialize(ms, transmissionDataList);
			}

			var service = new WebServiceReference.EmissionsWebServiceSoapClient();
			var transmitionDataMapper = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<TransferData, WebServiceReference.TransferData>();
			}).CreateMapper();

			var transmissionDataArray = new WebServiceReference.TransferData[transmissionDataList.Count()];

			for (int i = 0; i < transmissionDataList.Count(); i++)
			{
				transmissionDataArray[i] = transmitionDataMapper.Map<WebServiceReference.TransferData>(transmissionDataList[i]);
			}

			try
			{
				service.UploadData(transmissionDataArray);
				Console.WriteLine("Данные отправлены");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ошибка отправки данных: {0}", ex.Message);
			}
		}
	}
}