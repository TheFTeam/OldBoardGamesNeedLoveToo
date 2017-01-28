using Microsoft.Owin;
using OldBoardGamesNeedLoveToo.Data;
using Owin;

[assembly: OwinStartupAttribute(typeof(OldBoardGamesNeedLoveToo.Web.Startup))]
namespace OldBoardGamesNeedLoveToo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
