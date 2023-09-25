using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SGBWeb.Startup))]
namespace SGBWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
