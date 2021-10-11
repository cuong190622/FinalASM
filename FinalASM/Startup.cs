using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalASM.Startup))]
namespace FinalASM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
