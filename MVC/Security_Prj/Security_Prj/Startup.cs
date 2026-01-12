using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Security_Prj.Startup))]
namespace Security_Prj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
