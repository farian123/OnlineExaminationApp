using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineExaminationSystem.Startup))]
namespace OnlineExaminationSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
