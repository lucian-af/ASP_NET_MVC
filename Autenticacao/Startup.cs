using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autenticacao.Startup))]
namespace Autenticacao
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
