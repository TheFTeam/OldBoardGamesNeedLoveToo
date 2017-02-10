namespace OldBoardGamesNeedLoveToo.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCustomInfoes",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Role = c.Int(nullable: false),
                    Username = c.String(maxLength: 30),
                    FirstName = c.String(nullable: false, maxLength: 30),
                    LastName = c.String(nullable: false, maxLength: 30),
                    ApplicationUserId = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserCustomInfoId = c.Guid(nullable: true),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserCustomInfoes", t => t.UserCustomInfoId, cascadeDelete: true)
                .Index(t => t.UserCustomInfoId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);           
            
            
            //CreateTable(
            //    "dbo.Games",
            //    c => new
            //        {
            //            Id = c.Guid(nullable: false),
            //            Name = c.String(nullable: false, maxLength: 100),
            //            Desription = c.String(),
            //            Contents = c.String(nullable: false),
            //            Image = c.Binary(),
            //            Condition = c.Int(nullable: false),
            //            MinPlayers = c.Int(nullable: false),
            //            MaxPlayers = c.Int(nullable: false),
            //            MinAgeOfPlayers = c.Int(nullable: false),
            //            MaxAgeOfPlayers = c.Int(nullable: false),
            //            Language = c.String(nullable: false),
            //            ReleaseDate = c.DateTime(nullable: false),
            //            Producer = c.String(),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            isSold = c.Boolean(nullable: false),
            //            OwnerId = c.Guid(nullable: false),
            //            BuyerId = c.Guid(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.UserCustomInfoes", t => t.BuyerId)
            //    .ForeignKey("dbo.UserCustomInfoes", t => t.OwnerId, cascadeDelete: true)
            //    .Index(t => t.OwnerId)
            //    .Index(t => t.BuyerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserCustomInfoId", "dbo.UserCustomInfoes");
            DropForeignKey("dbo.Games", "OwnerId", "dbo.UserCustomInfoes");
            DropForeignKey("dbo.Games", "BuyerId", "dbo.UserCustomInfoes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Games", new[] { "BuyerId" });
            DropIndex("dbo.Games", new[] { "OwnerId" });
            DropIndex("dbo.UserCustomInfoes", new[] { "Username" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "UserCustomInfoId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.Games");
            DropTable("dbo.UserCustomInfoes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
