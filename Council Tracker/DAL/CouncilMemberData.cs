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

            string officePattern = @"<h1>(?<office>[A-Za-z0-9\-\s]*)<\/h1>";
            Regex officeRgx = new Regex(officePattern);
            Match officeMatch = officeRgx.Match(rawHtml);
            string office = officeMatch.Groups["office"].Value;
            viceMayor.Office = office;

            string photoPattern = @"images\/members\/(?<photo>.*?)"">";
            Regex photoRgx = new Regex(photoPattern);
            Match photoMatch = photoRgx.Match(rawHtml);
            string photo = photoMatch.Groups["photo"].Value;
            viceMayor.PhotoURL = "http://www.nashville.gov/portals/0/SiteContent/Council/images/members/" + photo;

            string namePattern = @">(?<name>[A-Za-z0-9\.\'\-\s]*)<\/h2>";
            Regex nameRgx = new Regex(namePattern);
            Match nameMatch = nameRgx.Match(rawHtml);
            string name = nameMatch.Groups["name"].Value;
            viceMayor.Name = name;

            string address = "One Public Square, Suite 204 P.O.Box 196300 Nashville, Tennessee 37219-6300";
            viceMayor.Address = address;

            string phonePattern = @"(?<phone>\(?[0-9]{3}\)?\-?\s?\.?[0-9]{3}\-?\s?\.?[0-9]{4})";
            Regex phoneRgx = new Regex(phonePattern);
            Match phoneMatch = phoneRgx.Match(rawHtml);
            string phone = phoneMatch.Groups["phone"].Value;
            viceMayor.Phone = phone;

            string emailPattern = @"mailto:(?<email>[A-Za-z]*\.?[A-Za-z]*\.?[A-Za-z]*\.?[A-Za-z]*\.?@nashville.gov)";
            Regex emailRgx = new Regex(emailPattern);
            Match emailMatch = emailRgx.Match(rawHtml);
            string email = emailMatch.Groups["email"].Value;
            viceMayor.Email = email;

            //string occupationPattern = @"";
            //Regex occupationRgx = new Regex(occupationPattern);
            //MatchCollection occupationMatch = occupationRgx.Matches(rawHtml);
            //List<string> occupation = occupationMatch.Groups["occupation"].Value;
            //viceMayor.Occupation = occupation;

            //string familyPattern = @"";
            //Regex addressRgx = new Regex(addressPattern);
            //Match addressMatch = addressRgx.Match(rawHtml);
            //string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            //string educationPattern = @"";
            //Regex addressRgx = new Regex(addressPattern);
            //Match addressMatch = addressRgx.Match(rawHtml);
            //string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            //string awardsPattern = @"";
            //Regex addressRgx = new Regex(addressPattern);
            //Match addressMatch = addressRgx.Match(rawHtml);
            //string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            //string experiencePattern = @"";
            //Regex addressRgx = new Regex(addressPattern);
            //Match addressMatch = addressRgx.Match(rawHtml);
            //string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            //string organizationsPattern = @"";
            //Regex addressRgx = new Regex(addressPattern);
            //Match addressMatch = addressRgx.Match(rawHtml);
            //string address = addressMatch.Groups["name"].Value;
            //viceMayor.Address = address;
            return viceMayor;
        }
        public CouncilMember[] seedAtLargeMembers()
        {
            WebClient client = new WebClient();
            CouncilMember[] atLargeMembersArray = new CouncilMember[5];

            for (var i = 1; i < 6; i++)
            {
                CouncilMember atLargeMember = new CouncilMember();
                string rawHtml = client.DownloadString($"http://www.nashville.gov/Metro-Council/Metro-Council-Members/At-Large-{i}-Council-Member.aspx");

                string officePattern = @"<h1>(?<office>[A-Za-z0-9\-\s]*)<\/h1>";
                Regex officeRgx = new Regex(officePattern);
                Match officeMatch = officeRgx.Match(rawHtml);
                string office = officeMatch.Groups["office"].Value;
                atLargeMember.Office = office;

                string photoPattern = @"<img\ssrc=""\/portals\/0\/SiteContent\/Council\/images\/members\/(?<photo>.*?)""";
                Regex photoRgx = new Regex(photoPattern);
                Match photoMatch = photoRgx.Match(rawHtml);
                string photo = photoMatch.Groups["photo"].Value;
                atLargeMember.PhotoURL = "http://www.nashville.gov/portals/0/SiteContent/Council/images/members/" + photo;

                string namePattern = @">(?<name>[A-Za-z0-9\.\'\-\s]*)<\/h2>";
                Regex nameRgx = new Regex(namePattern);
                Match nameMatch = nameRgx.Match(rawHtml);
                string name = nameMatch.Groups["name"].Value;
                atLargeMember.Name = name;

                string address = "One Public Square, Suite 204 P.O.Box 196300 Nashville, Tennessee 37219-6300";
                atLargeMember.Address = address;

                string phonePattern = @"(?<phone>\(?[0-9]{3}\)?\-?\s?\.?[0-9]{3}\-?\s?\.?[0-9]{4})";
                Regex phoneRgx = new Regex(phonePattern);
                Match phoneMatch = phoneRgx.Match(rawHtml);
                string phone = phoneMatch.Groups["phone"].Value;
                atLargeMember.Phone = phone;

                string emailPattern = @"mailto:(?<email>[A-Za-z]*\.?[A-Za-z]*\.?[A-Za-z]*\.?[A-Za-z]*\.?@nashville.gov)";
                Regex emailRgx = new Regex(emailPattern);
                Match emailMatch = emailRgx.Match(rawHtml);
                string email = emailMatch.Groups["email"].Value;
                atLargeMember.Email = email;

                atLargeMembersArray[i-1] = atLargeMember;
            }
            return atLargeMembersArray;
        }
        public CouncilMember[] seedDistrictedMembers()
        {
            WebClient client = new WebClient();
            CouncilMember[] districtedMembersArray = new CouncilMember[35];

            for (var i = 1; i < 36; i++)
            {
                CouncilMember districtMember = new CouncilMember();
                string rawHtml = client.DownloadString($"http://www.nashville.gov/Metro-Council/Metro-Council-Members/District-{i}-Council-Member.aspx");

                string officePattern = @"<h1>(?<office>[A-Za-z0-9\-\s]*)<\/h1>";
                Regex officeRgx = new Regex(officePattern);
                Match officeMatch = officeRgx.Match(rawHtml);
                string office = officeMatch.Groups["office"].Value;
                districtMember.Office = office;

                string namePattern = @">(?<name>[A-Za-z0-9\.\'\-\s]*)<\/h2>";
                Regex nameRgx = new Regex(namePattern);
                Match nameMatch = nameRgx.Match(rawHtml);
                string name = nameMatch.Groups["name"].Value;
                districtMember.Name = name;

                string photoPattern = @"<img\ssrc=""\/portals\/0\/SiteContent\/Council\/images\/members\/(?<photo>.*?)""";
                Regex photoRgx = new Regex(photoPattern);
                Match photoMatch = photoRgx.Match(rawHtml);
                string photo = photoMatch.Groups["photo"].Value;
                districtMember.PhotoURL = "http://www.nashville.gov/portals/0/SiteContent/Council/images/members/" + photo;

                string address = "One Public Square, Suite 204 P.O.Box 196300 Nashville, Tennessee 37219-6300";
                districtMember.Address = address;

                string phonePattern = @"(?<phone>\(?[0-9]{3}\)?\-?\s?\.?[0-9]{3}\-?\s?\.?[0-9]{4})";
                Regex phoneRgx = new Regex(phonePattern);
                Match phoneMatch = phoneRgx.Match(rawHtml);
                string phone = phoneMatch.Groups["phone"].Value;
                districtMember.Phone = phone;

                string emailPattern = @"mailto:(?<email>[A-Za-z]*\.?[A-Za-z]*\.?[A-Za-z]*\.?[A-Za-z]*\.?@nashville.gov)";
                Regex emailRgx = new Regex(emailPattern);
                Match emailMatch = emailRgx.Match(rawHtml);
                string email = emailMatch.Groups["email"].Value;
                districtMember.Email = email;

                districtedMembersArray[i - 1] = districtMember;
            }
            return districtedMembersArray;
        }
    }
}