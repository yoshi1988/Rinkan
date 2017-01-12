using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rinkan.Startup))]
namespace Rinkan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
