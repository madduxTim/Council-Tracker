using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Council_Tracker.Startup))]
namespace Council_Tracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
