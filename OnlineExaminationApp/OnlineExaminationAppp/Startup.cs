using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineExaminationAppp.Startup))]
namespace OnlineExaminationAppp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
