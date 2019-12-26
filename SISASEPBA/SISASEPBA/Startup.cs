using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SISASEPBA.Startup))]
namespace SISASEPBA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
