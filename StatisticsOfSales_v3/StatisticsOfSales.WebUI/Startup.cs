using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StatisticsOfSales.WebUI.Startup))]
namespace StatisticsOfSales.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
