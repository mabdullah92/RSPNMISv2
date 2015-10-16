using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RSPNMISv2.Startup))]
namespace RSPNMISv2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
