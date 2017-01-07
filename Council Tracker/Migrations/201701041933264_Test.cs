namespace Council_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ordinances", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.Resolutions", "Body", c => c.String(nullable: false));
            DropColumn("dbo.CouncilMembers", "PhotoURL");
            DropColumn("dbo.Ordinances", "Year");
            DropColumn("dbo.Resolutions", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resolutions", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Ordinances", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.CouncilMembers", "PhotoURL", c => c.String());
            AlterColumn("dbo.Resolutions", "Body", c => c.String());
            AlterColumn("dbo.Ordinances", "Body", c => c.String());
        }
    }
}
