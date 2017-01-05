namespace Council_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1417 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "testprop", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "testprop");
        }
    }
}
