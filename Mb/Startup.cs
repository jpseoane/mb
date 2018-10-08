using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mb.Startup))]
namespace Mb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
