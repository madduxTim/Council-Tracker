namespace Council_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoredForXMLReader : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ordinances", "Caption", c => c.String());
            AlterColumn("dbo.Resolutions", "Caption", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resolutions", "Caption", c => c.String(nullable: false));
            AlterColumn("dbo.Ordinances", "Caption", c => c.String(nullable: false));
        }
    }
}
