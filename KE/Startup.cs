using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KE.Startup))]
namespace KE
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
