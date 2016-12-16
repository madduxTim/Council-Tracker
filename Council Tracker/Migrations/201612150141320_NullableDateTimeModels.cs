namespace Council_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDateTimeModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ordinances", "EnactmentDate", c => c.DateTime());
            AlterColumn("dbo.Resolutions", "EnactmentDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resolutions", "EnactmentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Ordinances", "EnactmentDate", c => c.DateTime(nullable: false));
        }
    }
}
