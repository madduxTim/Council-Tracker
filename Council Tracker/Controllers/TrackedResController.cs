using Council_Tracker.DAL;
using Council_Tracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Council_Tracker.Controllers
{
    public class TrackedResController : ApiController
    {
        ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        CTrackerRepository repo = new CTrackerRepository();

        [HttpGet]
        [Route("api/TrackedRes/")]
        public List<Resolution> Get()
        {
            ApplicationUser user = userManager.FindById(User.Identity.GetUserId());
            List<Resolution> trackedRes = repo.GetTrackedResolutions(user.Id);
            return trackedRes;
        }
    }
}

