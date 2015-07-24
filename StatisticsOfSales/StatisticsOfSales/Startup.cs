using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StatisticsOfSales.Startup))]
namespace StatisticsOfSales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
