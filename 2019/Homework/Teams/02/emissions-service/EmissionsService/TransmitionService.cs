using AutoMapper;
using EmissionsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmissionsService
{
    class TransmitionService
    {
        public static void SendData(List<TransferData> transmissionDataList)
        {
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
                Console.WriteLine("Request performed succesfuly");
            }
            catch
            {
                Console.WriteLine("Request performed badly");
            }
        }
    }
}
