using Council_Tracker.DAL;
using Council_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace Council_Tracker.Controllers
{
    public class OrdinanceController : ApiController
    {
        CTrackerRepository repo = new CTrackerRepository();
        // GET api/<controller>
        public List<Ordinance> Get()
        {
            return repo.GetOrds();
        }

        public Ordinance Get(int id)
        {
            return repo.GetSingleOrd(id);
        }
    }
}