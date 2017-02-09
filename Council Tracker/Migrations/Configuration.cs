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
            Ordinance ordinance = new Ordinance();
            ApplicationUser user = new ApplicationUser();
            context.Ordinances.AddOrUpdate(
                ord => new { ord.OrdNumber },
                ordData.ordinanceScraper()
                );
            context.Resolutions.AddOrUpdate(
                res => new { res.ResNumber },
                resData.resolutionScraper()
                );
            context.Council_Members.AddOrUpdate(
                cm => new { cm.Name, cm.Office },
                data.seedDistrictedMembers()
            );
            context.Council_Members.AddOrUpdate(
                cm => new { cm.Name, cm.Office },
                data.seedViceMayor()
            );
            context.Council_Members.AddOrUpdate(
                cm => new { cm.Name, cm.Office },
                data.seedAtLargeMembers()
            );
        }
    }
}
