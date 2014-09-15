using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sln.Startup))]
namespace Sln
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
