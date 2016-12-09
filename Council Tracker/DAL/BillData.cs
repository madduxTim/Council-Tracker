using Council_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace Council_Tracker.DAL
{
    public class BillData
    {
        public Ordinance[] ordinanceScraper()
        {
            WebClient client = new WebClient();
            Ordinance[] scrapedOrds = new Ordinance[3];
            for (var i = 100; i < 102; i++)
            {
                Ordinance ordinance = new Ordinance();
                string rawHtml = client.DownloadString($"http://www.nashville.gov/mc/ordinances/term_2015_2019/bl2016_{i}.htm");

                string ordNumberPattern = @"<title>ORDINANCE NO. BL2016-(?<ordNumber>.*?)<\/title>";
                Regex ordNumberRgx = new Regex(ordNumberPattern);
                Match ordNumberMatch = ordNumberRgx.Match(rawHtml);
                string ordNumber = ordNumberMatch.Groups["ordNumber"].Value;
                ordinance.OrdNumber = Convert.ToInt32(ordNumber);

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
    }
}