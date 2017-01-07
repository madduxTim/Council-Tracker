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

        public Ordinance GetSingleOrd(int ordnumber)
        {
            Ordinance ord = Context.Ordinances.FirstOrDefault(o => o.OrdNumber == ordnumber);
            return ord;
        }

        public Resolution GetSingleRes(int resnumber)
        {
            Resolution res = Context.Resolutions.FirstOrDefault(r => r.ResNumber == resnumber);
            return res;
        }

        public CouncilMember GetSingleMember(int id)
        {
            CouncilMember member = Context.Council_Members.FirstOrDefault(c => c.ID == id);
            return member;
        }

        public void TrackOrdinance(int ordNumber, string userID)
        {
            var ordinance = Context.Ordinances.FirstOrDefault(o => o.OrdNumber == ordNumber);
            var user = Context.Users.FirstOrDefault(u => u.Id == userID);
            user.Ordinances.Add(ordinance);
            Context.SaveChanges();
        }
    }
}