using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamenPrimera.Startup))]
namespace ExamenPrimera
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
