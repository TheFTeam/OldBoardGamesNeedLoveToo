using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Data
{
    public class ObgnltContext : DbContext
    {
        public ObgnltContext()
            : base("OldBoardGamesNeedLoveToo")
        {

        }

        public virtual IDbSet<Game> Games { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(i => i.BoughtGames)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("Id");
                    x.MapRightKey("BuyerId")
                    .ToTable("BuyerBoughtGames");
                });

            modelBuilder.Entity<User>()
                .HasMany(i => i.SellingGames)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("Id");
                    x.MapRightKey("OwnerId")
                    .ToTable("OwnerSellingGames");
                });

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<Game>()
            //       .HasRequired(m => m.Owner)
            //       .WithMany(t => t.SellingGames)
            //       .HasForeignKey(m => m.OwnerId)
            //       .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Game>()
            //            .HasRequired(m => m.Buyer)
            //            .WithMany(t => t.BoughtGames)
            //            .HasForeignKey(m => m.BuyerId)
            //            .WillCascadeOnDelete(false);
        }
    }
}