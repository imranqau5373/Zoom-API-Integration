using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZoomWithOAuth.Startup))]
namespace ZoomWithOAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
