namespace Council_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YearPhotoURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CouncilMembers", "PhotoURL", c => c.String());
            AddColumn("dbo.Ordinances", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Resolutions", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.Ordinances", "Body", c => c.String());
            AlterColumn("dbo.Resolutions", "Body", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resolutions", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.Ordinances", "Body", c => c.String(nullable: false));
            DropColumn("dbo.Resolutions", "Year");
            DropColumn("dbo.Ordinances", "Year");
            DropColumn("dbo.CouncilMembers", "PhotoURL");
        }
    }
}
