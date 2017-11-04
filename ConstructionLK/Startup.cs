using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConstructionLK.Startup))]
namespace ConstructionLK
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
