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
            //CouncilMemberData data = new CouncilMemberData(); // Using this to test data from the seeding councilmember with a breakpoint at line 18
            //var ViceMayor = data.seedViceMayor();
            //var AtLarges = data.seedAtLargeMembers();
            //var districtMembers = data.seedDistrictedMembers();
            //ResolutionData resols = new ResolutionData();
            //resols.highestResNumCollector();
            //var blah = resols.resolutionScraper();
            //OrdinanceData bills = new OrdinanceData();
            //bills.highestOrdNumCollector();
            //var ords = bills.ordinanceScraper();
            //int blah = bills.numberOf2016Ords;
            //int blah2 = bills.numberOf2017Ords;
            //int blah3 = bills.numberOf2015Ords;
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
    }
}