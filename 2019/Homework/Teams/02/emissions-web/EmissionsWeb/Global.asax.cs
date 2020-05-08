using EmissionsLibrary;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;

namespace EmissionsWeb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Код, выполняемый при запуске приложения
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RouteTable.Routes.MapHttpRoute(
                name: "Api",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = System.Web.Http.RouteParameter.Optional }
            );

            Application.Lock();
            Application["Measurements"] = new HashSet<TransferData>(new TransferDataComparer());
            Application.UnLock();
        }
    }

    public class TransferDataComparer : IEqualityComparer<TransferData>
    {
        public bool Equals(TransferData x, TransferData y)
        {
            return x.valueUuid == y.valueUuid;
        }

        public int GetHashCode(TransferData obj)
        {
            return obj.valueUuid.GetHashCode();
        }
    }
}