using Council_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Council_Tracker.DAL
{
    public class CTrackerRepository
    {
        public CTrackerContext Context { get; set; }
        public CTrackerRepository(CTrackerContext _context)
        {
            Context = _context;
        }

        public CTrackerRepository()
        {
            Context = new CTrackerContext();
        }

        public void ManuallyAddOrd(Ordinance ord)
        {
            Context.Ordinances.Add(ord);
            Context.SaveChanges();
        }
        public List<Ordinance> GetOrds()
        {
            return Context.Ordinances.ToList();
        }

        public void ManuallyAddRes(Resolution res)
        {
            Context.Resolutions.Add(res);
            Context.SaveChanges();
        }

        public List<Resolution> GetResolutions()
        {
            return Context.Resolutions.ToList();
        }

        public void ManuallyAddMember(CouncilMember mem)
        {
            Context.Council_Members.Add(mem);
            Context.SaveChanges();
        }
        public List<CouncilMember> GetMembers()
        {
            return Context.Council_Members.ToList();
        }
    }
}