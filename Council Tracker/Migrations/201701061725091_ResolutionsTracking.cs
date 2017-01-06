namespace Council_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResolutionsTracking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resolutions", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Resolutions", "ApplicationUser_Id");
            AddForeignKey("dbo.Resolutions", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resolutions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Resolutions", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Resolutions", "ApplicationUser_Id");
        }
    }
}
