using Council_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Council_Tracker.DAL
{
    public class CTrackerContext : ApplicationDbContext
    {
        //public CTrackerContext():base("name=CTrackerContext")
        //{
        //    this.
        //}
        public virtual DbSet<CouncilMember> Council_Members { get; set; }
        public virtual DbSet<Ordinance> Ordinances { get; set; }
        public virtual DbSet<Resolution> Resolutions { get; set; }
    }
}