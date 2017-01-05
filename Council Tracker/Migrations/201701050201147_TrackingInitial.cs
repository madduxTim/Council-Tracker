namespace Council_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrackingInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserOrdinances",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Ordinance_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Ordinance_ID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ordinances", t => t.Ordinance_ID, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Ordinance_ID);
            
            DropColumn("dbo.AspNetUsers", "testprop");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "testprop", c => c.String());
            DropForeignKey("dbo.ApplicationUserOrdinances", "Ordinance_ID", "dbo.Ordinances");
            DropForeignKey("dbo.ApplicationUserOrdinances", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserOrdinances", new[] { "Ordinance_ID" });
            DropIndex("dbo.ApplicationUserOrdinances", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserOrdinances");
        }
    }
}
