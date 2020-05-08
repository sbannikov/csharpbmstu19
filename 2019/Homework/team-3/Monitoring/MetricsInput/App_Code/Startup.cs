using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MetricsInput.Startup))]
namespace MetricsInput
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
