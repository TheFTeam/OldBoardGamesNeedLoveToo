namespace OldBoardGamesNeedLoveToo.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCustomInfoes", "Email", c => c.String());
            AddColumn("dbo.UserCustomInfoes", "Phone", c => c.String());
            AddColumn("dbo.UserCustomInfoes", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserCustomInfoes", "Address");
            DropColumn("dbo.UserCustomInfoes", "Phone");
            DropColumn("dbo.UserCustomInfoes", "Email");
        }
    }
}
