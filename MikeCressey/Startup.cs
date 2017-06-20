using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MikeCressey.Startup))]
namespace MikeCressey
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
