using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCLoginPortal.Startup))]
namespace MVCLoginPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
