using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFilter.Startup))]
namespace MyFilter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
