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
    }
}