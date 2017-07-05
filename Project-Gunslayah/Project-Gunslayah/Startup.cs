using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_Gunslayah.Startup))]
namespace Project_Gunslayah
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
