using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreenGoats.Startup))]
namespace GreenGoats
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
