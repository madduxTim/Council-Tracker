﻿using Council_Tracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Council_Tracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult OrdinancesIndex()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Resolutions()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Council_Members()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Ordinance()
        {
            return View();
        }
    }
}