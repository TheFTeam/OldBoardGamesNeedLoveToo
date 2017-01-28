namespace OldBoardGamesNeedLoveToo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Desription = c.String(),
                        Contents = c.String(nullable: false),
                        Image = c.Binary(),
                        Condition = c.Int(nullable: false),
                        MinPlayers = c.Int(nullable: false),
                        MaxPlayers = c.Int(nullable: false),
                        AgeOfPlayers = c.Int(nullable: false),
                        Language = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Producer = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isSold = c.Boolean(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        BuyerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.BuyerId)
                .ForeignKey("dbo.Users", t => t.OwnerId)
                .Index(t => t.OwnerId)
                .Index(t => t.BuyerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.Int(nullable: false),
                        Username = c.String(maxLength: 30),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        HashPassword = c.String(),
                        PhoneNumber = c.String(maxLength: 20),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.BuyerBoughtGames",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        BuyerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.BuyerId })
                .ForeignKey("dbo.Users", t => t.Id)
                .ForeignKey("dbo.Games", t => t.BuyerId)
                .Index(t => t.Id)
                .Index(t => t.BuyerId);
            
            CreateTable(
                "dbo.OwnerSellingGames",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.OwnerId })
                .ForeignKey("dbo.Users", t => t.Id)
                .ForeignKey("dbo.Games", t => t.OwnerId)
                .Index(t => t.Id)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.Games", "BuyerId", "dbo.Users");
            DropForeignKey("dbo.OwnerSellingGames", "OwnerId", "dbo.Games");
            DropForeignKey("dbo.OwnerSellingGames", "Id", "dbo.Users");
            DropForeignKey("dbo.BuyerBoughtGames", "BuyerId", "dbo.Games");
            DropForeignKey("dbo.BuyerBoughtGames", "Id", "dbo.Users");
            DropIndex("dbo.OwnerSellingGames", new[] { "OwnerId" });
            DropIndex("dbo.OwnerSellingGames", new[] { "Id" });
            DropIndex("dbo.BuyerBoughtGames", new[] { "BuyerId" });
            DropIndex("dbo.BuyerBoughtGames", new[] { "Id" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Games", new[] { "BuyerId" });
            DropIndex("dbo.Games", new[] { "OwnerId" });
            DropTable("dbo.OwnerSellingGames");
            DropTable("dbo.BuyerBoughtGames");
            DropTable("dbo.Users");
            DropTable("dbo.Games");
        }
    }
}
