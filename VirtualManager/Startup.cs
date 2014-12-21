using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VirtualManager.Startup))]
namespace VirtualManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
