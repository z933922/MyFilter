using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KO.Startup))]
namespace KO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
