using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Council_Tracker.Models;

namespace Council_Tracker.Controllers
{
    public class UserController : ApiController
    {
        ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        // GET api/<controller>/5
        public string Get()
        {
            //ApplicationUser user = userManager.FindById(User.Identity.GetUserId());
            //return user.Id;
            return "0677d5ba-83b0-4aea-8f8a-a6d97199cba2";
        }

        public dynamic Post([FromBody]dynamic bill)
        {
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {

            } else
            {
                return "that didn't work dude, sorry.";
            }
            return "nice work";
        }
    }
}