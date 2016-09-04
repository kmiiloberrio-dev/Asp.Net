using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Asp.Net_MVC.Startup))]
namespace Asp.Net_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
