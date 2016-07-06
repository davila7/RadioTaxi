using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AG_beta6.Startup))]
namespace AG_beta6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
