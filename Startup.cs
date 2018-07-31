using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MostSnake.Startup))]
namespace MostSnake
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
