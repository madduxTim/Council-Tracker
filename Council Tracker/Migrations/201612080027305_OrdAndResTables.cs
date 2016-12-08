namespace Council_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdAndResTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ordinances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrdNumber = c.Int(nullable: false),
                        Body = c.String(nullable: false),
                        Caption = c.String(nullable: false),
                        CurrentStatus = c.String(),
                        EnactmentDate = c.DateTime(nullable: false),
                        ExhibitURL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Resolutions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ResNumber = c.Int(nullable: false),
                        Body = c.String(nullable: false),
                        Caption = c.String(nullable: false),
                        CurrentStatus = c.String(),
                        EnactmentDate = c.DateTime(nullable: false),
                        ExhibitURL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.CouncilMembers", "Ordinance_ID", c => c.Int());
            AddColumn("dbo.CouncilMembers", "Resolution_ID", c => c.Int());
            CreateIndex("dbo.CouncilMembers", "Ordinance_ID");
            CreateIndex("dbo.CouncilMembers", "Resolution_ID");
            AddForeignKey("dbo.CouncilMembers", "Ordinance_ID", "dbo.Ordinances", "ID");
            AddForeignKey("dbo.CouncilMembers", "Resolution_ID", "dbo.Resolutions", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CouncilMembers", "Resolution_ID", "dbo.Resolutions");
            DropForeignKey("dbo.CouncilMembers", "Ordinance_ID", "dbo.Ordinances");
            DropIndex("dbo.CouncilMembers", new[] { "Resolution_ID" });
            DropIndex("dbo.CouncilMembers", new[] { "Ordinance_ID" });
            DropColumn("dbo.CouncilMembers", "Resolution_ID");
            DropColumn("dbo.CouncilMembers", "Ordinance_ID");
            DropTable("dbo.Resolutions");
            DropTable("dbo.Ordinances");
        }
    }
}
