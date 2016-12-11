using Council_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace Council_Tracker.DAL
{

    public class OrdinanceData
    {
        public int latestOrdinanceNumber = 0;
        public void highestOrdNumCollector()
        {
            WebClient client = new WebClient();
            string indexHTML = client.DownloadString($"http://www.nashville.gov/Metro-Clerk/Legislative/Ordinances/2015-2019.aspx");
            string ordNumberPattern = @"<a href=""http:\/\/www\.nashville\.gov\/mc\/ordinances\/term_2015_2019\/bl2016_(?<num>.*?)\.htm"">";
            Regex ordNumberRgx = new Regex(ordNumberPattern);
            MatchCollection ordNumberMatch = ordNumberRgx.Matches(indexHTML);
            string ordNumber = ordNumberMatch[0].Groups["num"].Value; 
            int highest = Convert.ToInt32(ordNumber);
            latestOrdinanceNumber = highest-100; // 100 Reflects the number of Ords from the previous year
        }
        public Ordinance[] ordinanceScraper()
        {
            WebClient client = new WebClient();
            highestOrdNumCollector();
            Ordinance[] scrapedOrds = new Ordinance[latestOrdinanceNumber];
            for (var i = 100; i < latestOrdinanceNumber+1; i++) 
            {
                Ordinance ordinance = new Ordinance();
                string rawHtml = client.DownloadString($"http://www.nashville.gov/mc/ordinances/term_2015_2019/bl2016_{i}.htm");

                ordinance.OrdNumber = i; 

                string bodyTextPattern = @"<p class=""ordinancecontent"">(?<body>.)*<\/p>";
                Regex bodyTextRgx = new Regex(bodyTextPattern);
                MatchCollection bodyTextMatch = bodyTextRgx.Matches(rawHtml);
                //List<string> textsList = new List<string>();
                string bodyText = "";
                for (var j = 0; j < bodyTextMatch.Count; j++)
                {
                    string match = bodyTextMatch[j].ToString();
                    //textsList.Add(match);
                    bodyText += match;
                }
                ordinance.Body = bodyText;

                string captionPattern = @"<\/font><\/b>(?<caption>An ordinance.*?)<\/p>";
                Regex captionRgx = new Regex(captionPattern);
                Match captionMatch = captionRgx.Match(rawHtml);
                string caption = captionMatch.Groups["caption"].Value;
                ordinance.Caption = caption;

                // NEEDS TO BE REFACTORED INTO A DICTIONARY SO THAT IT CAN CONTAIN A STRING URL AND A STRING NAME...
                //string exhibitURLsPattern = @"<p class=""ordinancecontent""><a href=""(?< body >.)*"">(?<docName>.)*<\/a><\/p>";
                //Regex exhibitURLsRgx = new Regex(exhibitURLsPattern);
                //MatchCollection exhibitURLsMatch = exhibitURLsRgx.Matches(rawHtml);
                ////List<string> textsList = new List<string>();
                //string exhibitURLs = "";
                //for (var j = 0; j < exhibitURLsMatch.Count; j++)
                //{
                //    string match = exhibitURLsMatch[j].ToString();
                //    //textsList.Add(match);
                //    exhibitURLs += match;
                //}
                //ordinance.Body = exhibitURLs;

                //string statusPattern = @"";
                //Regex statusRgx = new Regex(statusPattern);
                //Match statusMatch = statusRgx.Match(rawHtml);
                //string status = statusMatch.Groups["status"].Value;
                //ordinance.CurrentStatus = status;

                //string sponsorPattern = @"Sponsored by: (?<sponsor>.*?)<\/p>";
                //Regex sponsorRgx = new Regex(sponsorPattern);
                //Match sponsorMatch = sponsorRgx.Match(rawHtml);
                //string sponsor = sponsorMatch.Groups["sponsor"].Value; // probably need .Trim() ?? 
                //ordinance.Sponsor = List<sponsor>;

                //string codePattern = @"";
                //Regex codeRgx = new Regex(codePattern);
                //Match codeMatch = codeRgx.Match(rawHtml);
                //string codeText = codeMatch.Groups["codes"].Value;
                //ordinance.CodeSections = codeText;


                //string historyPattern = @"";
                //Regex historyRgx = new Regex(historyPattern);
                //Match historyMatch = historyRgx.Match(rawHtml);
                //string history = historyMatch.Groups["history"].Value;
                //ordinance.History = history;

                //string enactmentDatePattern = @"";
                //Regex enactmentDateRgx = new Regex(enactmentDatePattern);
                //Match enactmentDateMatch = enactmentDateRgx.Match(rawHtml);
                //DateTime enactmentDate = enactmentDateMatch.Groups["name"].Value;
                //ordinance.EnactmentDate = enactmentDate;

                scrapedOrds[i - 100] = ordinance;
            }
            return scrapedOrds;
        }
        //public void billscrapeCleaner()
        //{
            //Ideally this goes in the middle of ordinance scrape to clean up the body text. Keep an eye out for bills that include docs/graphs/tables, etc. Need to know how to handle. 
        //}
    }
}