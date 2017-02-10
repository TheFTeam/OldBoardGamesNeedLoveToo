namespace OldBoardGamesNeedLoveToo.Web.Migrations
{
    using System.Data.Entity.Migrations;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using OldBoardGamesNeedLoveToo.Models;

    public sealed class Configuration
        : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists((UserRoleType.Admin).ToString()))
            {
                var role = new IdentityRole();
                role.Name = (UserRoleType.Admin).ToString();
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists((UserRoleType.User).ToString()))
            {
                var role = new IdentityRole();
                role.Name = (UserRoleType.User).ToString();
                roleManager.Create(role);
            }
        }
    }
}