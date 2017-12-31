using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GymClass_v0._2.Startup))]
namespace GymClass_v0._2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
