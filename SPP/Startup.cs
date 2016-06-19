using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SPP.Startup))]
namespace SPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
