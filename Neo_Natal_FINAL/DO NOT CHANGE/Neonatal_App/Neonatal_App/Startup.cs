using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Neonatal_App.Startup))]
namespace Neonatal_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
