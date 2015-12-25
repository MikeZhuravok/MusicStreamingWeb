using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicStreamingWeb.Startup))]
namespace MusicStreamingWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
