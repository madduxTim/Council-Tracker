namespace Council_Tracker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Council_Tracker.DAL;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Council_Tracker.DAL.CTrackerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Council_Tracker.DAL.CTrackerContext context)
        {
            CouncilMemberData data = new CouncilMemberData();
            context.Council_Members.AddOrUpdate(
                    cm => new { cm.Name, cm.Office }, //Reminder, this is checking that the name and office are unique
                    data.seedViceMayor() // Was not allowing me to seed with muliple methods from the councilmemberdata...
                                         //data.seedAtLargeMembers()
                                         //data.seedDistrictedMembers()


                //at-large CMs
                //district CMS
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
