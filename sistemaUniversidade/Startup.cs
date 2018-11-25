using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sistemaUniversidade.Startup))]
namespace sistemaUniversidade
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
