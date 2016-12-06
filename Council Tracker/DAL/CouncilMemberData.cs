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

        public CouncilMember seedViceMayor()
        {
            WebClient client = new WebClient();
            CouncilMember viceMayor = new CouncilMember();
            string rawHtml = client.DownloadString($"http://www.nashville.gov/Metro-Council/Metro-Council-Members/Vice-Mayor.aspx");
            string officePattern = @"<h1>(?<office>[A-Za-z]*\s[A-Za-z]*\s?[A-Za-z]*\s?[A-Za-z]*\s?)<\/h1>";
            Regex officeRgx = new Regex(officePattern);
            Match officeMatch = officeRgx.Match(rawHtml);
            string office = officeMatch.Groups["office"].Value;
            viceMayor.Office = office;
            string namePattern = @"""imgbdrright""\s\/>(?<name>[A-za-z]*\s[A-za-z]*\s?[A-za-z]*\s?[A-za-z]*\s?[A-za-z]*\s?[A-za-z]*\s?)<\/h2>";
            Regex nameRgx = new Regex(namePattern);
            Match nameMatch = nameRgx.Match(rawHtml);
            string name = nameMatch.Groups["name"].Value;
            viceMayor.Name = name;
            string addressPattern = @"";
            Regex addressRgx = new Regex(addressPattern);
            Match addressMatch = addressRgx.Match(rawHtml);
            string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            ////string phonePattern = @"";
            //Regex addressRgx = new Regex(addressPattern);
            //Match addressMatch = addressRgx.Match(rawHtml);
            //string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            ////string emailPattern = @"";
            //Regex addressRgx = new Regex(addressPattern);
            //Match addressMatch = addressRgx.Match(rawHtml);
            //string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            ////string occupationPattern = @"";
            //Regex addressRgx = new Regex(addressPattern);
            //Match addressMatch = addressRgx.Match(rawHtml);
            //string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            ////string familyPattern = @"";
            //Regex addressRgx = new Regex(addressPattern);
            //Match addressMatch = addressRgx.Match(rawHtml);
            //string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            ////string educationPattern = @"";
            //Regex addressRgx = new Regex(addressPattern);
            //Match addressMatch = addressRgx.Match(rawHtml);
            //string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            ////string awardsPattern = @"";
            //Regex addressRgx = new Regex(addressPattern);
            //Match addressMatch = addressRgx.Match(rawHtml);
            //string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            ////string experiencePattern = @"";
            //Regex addressRgx = new Regex(addressPattern);
            //Match addressMatch = addressRgx.Match(rawHtml);
            //string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            ////string organizationsPattern = @"";
            //Regex addressRgx = new Regex(addressPattern);
            //Match addressMatch = addressRgx.Match(rawHtml);
            //string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            return viceMayor;
        }
        // Kate says return an array when returning multiple CMs for other method (seed method only)
    }
}