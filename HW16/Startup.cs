using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HW16.Startup))]
namespace HW16
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
