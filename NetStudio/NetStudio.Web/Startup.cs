using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetStudio.Web.Startup))]
namespace NetStudio.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
