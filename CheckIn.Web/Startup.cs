using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckIn.Web.Startup))]
namespace CheckIn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
