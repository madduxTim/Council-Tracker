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

        public List<Ordinance> GetOrds()
        {
            return Context.Ordinances.ToList();
        }

        public List<Resolution> GetResolutions()
        {
            return Context.Resolutions.ToList();
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

        public ApplicationUser ReturnUser(string userId)
        {
            ApplicationUser found_user = Context.Users.FirstOrDefault(u => u.Id == userId);
            return found_user;
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
            Ordinance ordinance = Context.Ordinances.FirstOrDefault(o => o.OrdNumber == ordNumber);
            ApplicationUser user = Context.Users.FirstOrDefault(u => u.Id == userID);
            ordinance.Users.Add(user);
            Context.SaveChanges();
        }
        public void UntrackOrdinance(int ordNumber, string userID)
        {
            Ordinance ordinance = Context.Ordinances.FirstOrDefault(o => o.OrdNumber == ordNumber);
            ApplicationUser user = Context.Users.FirstOrDefault(u => u.Id == userID);
            ordinance.Users.Remove(user);
            Context.SaveChanges();
        }

        public void TrackResolution(int resNumber, string userID)
        {
            Resolution resolution = Context.Resolutions.FirstOrDefault(r => r.ResNumber == resNumber);
            ApplicationUser user = Context.Users.FirstOrDefault(u => u.Id == userID);
            resolution.Users.Add(user);
            Context.SaveChanges(); 
        }
        public void UntrackResolution(int resNumber, string userID)
        {
            Resolution resolution = Context.Resolutions.FirstOrDefault(r => r.ResNumber == resNumber);
            ApplicationUser user = Context.Users.FirstOrDefault(u => u.Id == userID);
            resolution.Users.Remove(user);
            Context.SaveChanges();
        }

    }
}