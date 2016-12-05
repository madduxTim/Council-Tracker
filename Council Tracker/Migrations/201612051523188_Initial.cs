namespace Council_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CouncilMembers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Office = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CouncilMembers");
        }
    }
}
