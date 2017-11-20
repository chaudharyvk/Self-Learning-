using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoolBlue.PointofSale.UI.Startup))]
namespace CoolBlue.PointofSale.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
