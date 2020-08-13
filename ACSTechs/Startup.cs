using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ACSTechs.Startup))]
namespace ACSTechs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
