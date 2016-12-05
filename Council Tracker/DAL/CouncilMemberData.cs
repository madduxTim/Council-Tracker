using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using Council_Tracker.Models;
using System.IO;

namespace Council_Tracker.DAL
{
    public class CouncilMemberData
    {
        WebClient client = new WebClient();

        public string seedViceMayor()
        {
            CouncilMember viceMayor = new CouncilMember();
            string rawHtml = client.DownloadString($"http://www.nashville.gov/Metro-Council/Metro-Council-Members/Vice-Mayor.aspx");
            string officeRegex = "<h1>[A-Za-z]*\s[A-Za-z]*\s?[A-Za-z]*\s?[A-Za-z]*\s?<\/h1>";
            //return viceMayor;
            return rawHtml;
        }
    }
}