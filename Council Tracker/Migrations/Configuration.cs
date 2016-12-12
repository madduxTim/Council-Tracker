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
            OrdinanceData ordData = new OrdinanceData();
            ResolutionData resData = new ResolutionData();
            context.Ordinances.AddOrUpdate(
                ord => new { ord.Caption },
                ordData.ordinanceScraper()
                );
            //context.Resolutions.AddOrUpdate(
            //    res => new { res.ResNumber },
            //    resData.resolutionScraper()
            //    );
            //context.Council_Members.AddOrUpdate(
            //cm => new { cm.Name, cm.Office },   //Reminder, this is checking that the name and office are unique
            //data.seedViceMayor()                  // Was not allowing me to seed with muliple methods from the councilmemberdata...
            //data.seedAtLargeMembers()
            //data.seedDistrictedMembers()
            //);
        }
    }
}
