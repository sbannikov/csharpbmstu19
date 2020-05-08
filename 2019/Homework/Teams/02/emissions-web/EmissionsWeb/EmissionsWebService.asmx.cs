using EmissionsLibrary;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace EmissionsWeb
{
    /// <summary>
    /// Сервис для получения данных от службы windows
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class EmissionsWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public void UploadData(TransferData[] data)
        {
            try
            {
                var currentData = (HashSet<TransferData>)HttpContext.Current.Application["Measurements"];
                currentData.UnionWith(data);
                
                HttpContext.Current.Application.Lock();
                Application["Measurements"] = currentData;
                HttpContext.Current.Application.UnLock();
            }
            catch { }
        } 
    }
}
