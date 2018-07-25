using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyUA.Startup))]
namespace VidlyUA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
