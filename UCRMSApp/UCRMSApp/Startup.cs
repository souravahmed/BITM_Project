using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UCRMSApp.Startup))]
namespace UCRMSApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
