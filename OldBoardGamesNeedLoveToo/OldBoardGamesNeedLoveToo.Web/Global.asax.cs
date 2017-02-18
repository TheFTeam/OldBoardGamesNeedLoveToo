using System;
using System.Data.Entity;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

using OldBoardGamesNeedLoveToo.Data;
using OldBoardGamesNeedLoveToo.Data.Migrations;

namespace OldBoardGamesNeedLoveToo.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            //using (var dbContext = new ObgnltContext())
            //{
            //    dbContext.Database.CreateIfNotExists();
            //}

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ObgnltContext, Configuration>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, OldBoardGamesNeedLoveToo.Web.Migrations.Configuration>());


            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}