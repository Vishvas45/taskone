using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskEntityFramework.Startup))]
namespace TaskEntityFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
