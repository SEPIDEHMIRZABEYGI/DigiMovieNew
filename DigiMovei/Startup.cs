using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DigiMovei.Startup))]
namespace DigiMovei
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
