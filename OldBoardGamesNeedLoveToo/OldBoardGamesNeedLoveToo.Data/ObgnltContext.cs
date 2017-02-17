using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Data
{
    public class ObgnltContext : DbContext, IObgnltContext
    {
        public ObgnltContext()
            : base("OldBoardGamesNeedLoveToo")
        {

        }

        public virtual IDbSet<Game> Games { get; set; }

        public virtual IDbSet<UserCustomInfo> UsersCustomInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<UserCustomInfo>()
                .HasMany(i => i.BoughtGames)
                .WithOptional(u => u.Buyer)
                .Map(x =>
                {
                    x.MapKey("Id");
                    x.ToTable("BuyerBoughtGames");
                });

            modelBuilder.Entity<UserCustomInfo>()
                .HasMany(i => i.SellingGames)
                .WithRequired(u => u.Owner)
                .Map(x =>
                {
                    x.MapKey("Id");
                    x.ToTable("OwnerSellingGames");
                });



            modelBuilder.Entity<Game>()
                   .HasMany(g => g.Comments)
                   .WithRequired(g => g.Game)
                   .HasForeignKey(g => g.GameId)
                   .WillCascadeOnDelete(true);

            //modelBuilder.Entity<UserCustomInfo>()
            //       .HasMany(u => u.Comments)
            //       .WithRequired()
            //       .WillCascadeOnDelete(false);
        }
    }
}