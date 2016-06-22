using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestRequre.Startup))]
namespace TestRequre
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
