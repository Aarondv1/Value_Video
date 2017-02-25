using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Value_Video.Startup))]
namespace Value_Video
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
