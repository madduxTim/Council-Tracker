using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Council_Tracker.Models;
using Council_Tracker.DAL;

namespace Council_Tracker.Tests.DAL
{
    [TestClass]
    public class ScrapeTesting
    {
        private CouncilMemberData data { get; set; }

        [TestMethod]
        public void CanSeedViceMayorData()
        {
            WebClient client = new WebClient();
            //CouncilMember vicemayor = new CouncilMember();

            string vicemayor = data.seedViceMayor();
            Assert.IsNotNull(vicemayor);
        }
    }
}
