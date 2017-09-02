using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DomainDrivenDesign.Web.Startup))]
namespace DomainDrivenDesign.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
