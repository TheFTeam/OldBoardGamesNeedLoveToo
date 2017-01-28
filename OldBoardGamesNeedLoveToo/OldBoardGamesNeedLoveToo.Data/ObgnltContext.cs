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
                .WithRequired(u => u.Buyer)
                .Map(x =>
                {
                    x.MapKey("Id");
                    x.ToTable("BuyerBoughtGames");
                });

            modelBuilder.Entity<User>()
                .HasMany(i => i.SellingGames)
                .WithRequired(u => u.Owner)
                .Map(x =>
                {
                    x.MapKey("Id");
                    x.ToTable("OwnerSellingGames");
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