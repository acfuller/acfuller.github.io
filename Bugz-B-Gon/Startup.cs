using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bugz_B_Gon.Startup))]
namespace Bugz_B_Gon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
