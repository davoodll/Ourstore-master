using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OurStore.Startup))]
namespace OurStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
