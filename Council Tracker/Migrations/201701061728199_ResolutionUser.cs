namespace Council_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResolutionUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resolutions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Resolutions", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.ResolutionApplicationUsers",
                c => new
                    {
                        Resolution_ID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Resolution_ID, t.ApplicationUser_Id })
                .ForeignKey("dbo.Resolutions", t => t.Resolution_ID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Resolution_ID)
                .Index(t => t.ApplicationUser_Id);
            
            DropColumn("dbo.Resolutions", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resolutions", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.ResolutionApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ResolutionApplicationUsers", "Resolution_ID", "dbo.Resolutions");
            DropIndex("dbo.ResolutionApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ResolutionApplicationUsers", new[] { "Resolution_ID" });
            DropTable("dbo.ResolutionApplicationUsers");
            CreateIndex("dbo.Resolutions", "ApplicationUser_Id");
            AddForeignKey("dbo.Resolutions", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
