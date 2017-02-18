using Microsoft.AspNet.Identity.EntityFramework;

namespace OldBoardGamesNeedLoveToo.Auth
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("OldBoardGamesNeedLoveToo", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}