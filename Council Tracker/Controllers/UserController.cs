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
            ApplicationUser loggedInUser = userManager.FindById(User.Identity.GetUserId());
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                // replacing the hash with bill.UserID?? DO I EVEN NEED THIS? 
                //if (loggedInUser.Id == "0677d5ba-83b0-4aea-8f8a-a6d97199cba2" && bill.type == "Ordinance") 
                if (bill.type == "Ordinance")
                {
                    loggedInUser.Ordinances.Add(bill.ordNumber);
                }
                //else if (loggedInUser.Id == "0677d5ba-83b0-4aea-8f8a-a6d97199cba2" && bill.type == "Resolution")
                else if (bill.type == "Resolution")
                {
                    loggedInUser.Resolutions.Add(bill.resNumber);
                }
                return "Posted. Nice work.";
            }
            else
            {
                return "Error! Bummer dude.";
            }
        }
    }
}