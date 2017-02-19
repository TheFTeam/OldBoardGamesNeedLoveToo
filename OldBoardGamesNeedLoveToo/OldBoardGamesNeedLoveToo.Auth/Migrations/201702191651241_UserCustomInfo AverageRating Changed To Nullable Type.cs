namespace OldBoardGamesNeedLoveToo.Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCustomInfoAverageRatingChangedToNullableType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserCustomInfoes", "SumOfUsersRating", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserCustomInfoes", "SumOfUsersRating", c => c.Int(nullable: false));
        }
    }
}
