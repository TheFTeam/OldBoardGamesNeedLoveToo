namespace OldBoardGamesNeedLoveToo.Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Commentsuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "PostedByUserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "PostedByUserName");
        }
    }
}
