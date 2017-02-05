namespace OldBoardGamesNeedLoveToo.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration
        : DbMigrationsConfiguration<ObgnltContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "OldBoardGamesNeedLoveToo.Data.ObgnltContext";
        }

        protected override void Seed(ObgnltContext context)
        {
            if (!context.Users.Any())
            {
                var firstUser = new User()
                {
                    FirstName = "Pesho",
                    LastName = "Pertov",
                    Email = "pesho@pesho.bg",
                    PhoneNumber = "123123456",
                    Role = UserRoleType.User,
                    Username = "pesho",
                    HashPassword = "12345pP!"
                };

                context.Users.AddOrUpdate(u => u.Username, firstUser);
                context.SaveChanges();
            }

            if (!context.Games.Any())
            {
                var firstGame = new Game()
                {
                    Name = "Activities",
                    Desription = "This is a very amuzing game.",
                    Contents = "a board, dice, 3 sets of cads",
                    Condition = ConditionType.VeryGood,
                    MinPlayers = 2,
                    MaxPlayers = 15,
                    MinAgeOfPlayers = 8,
                    MaxAgeOfPlayers = 100,
                    Language = "English",
                    ReleaseDate = DateTime.Parse("2015-10-23"),
                    Producer = "Games Enterprise",
                    Price = 35,
                    OwnerId = 1
                };

                var secondGame = new Game()
                {
                    Name = "Dixit",
                    Desription = "This is a very amuzing game too.",
                    Contents = "a board, dice, 2 sets of cads",
                    Condition = ConditionType.Excellent,
                    MinPlayers = 2,
                    MaxPlayers = 15,
                    MinAgeOfPlayers = 12,
                    MaxAgeOfPlayers = 100,
                    Language = "English",
                    ReleaseDate = DateTime.Parse("2016-10-23"),
                    Producer = "Games Enterprise",
                    Price = 45,
                    OwnerId = 1
                };

                context.Games.AddOrUpdate(g => g.Name, firstGame);
                context.SaveChanges();
            }
        }
    }
}