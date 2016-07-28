using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicketTrader.Startup))]
namespace TicketTrader
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
