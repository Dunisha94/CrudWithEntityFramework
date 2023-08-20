using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCrudWithEntityFramework.Startup))]
namespace MVCCrudWithEntityFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
