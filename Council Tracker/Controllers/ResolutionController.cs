using Council_Tracker.DAL;
using Council_Tracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace Council_Tracker.Controllers
{
    public class ResolutionController : ApiController
    {
        CTrackerRepository repo = new CTrackerRepository();
        // GET api/<controller>
        public List<Resolution> Get()
        {
            return repo.GetResolutions();
        }

        public Resolution Get(int id)
        {
            return repo.GetSingleRes(id);
        }
    }
}