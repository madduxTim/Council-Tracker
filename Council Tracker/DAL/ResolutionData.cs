using Council_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace Council_Tracker.DAL
{

    public class ResolutionData
    {
        public int latestResolutionNumber = 0;
        public void highestResNumCollector()
        {
            WebClient client = new WebClient();
            string indexHTML = client.DownloadString($"http://www.nashville.gov/Metro-Clerk/Legislative/Resolutions/2015-2019.aspx");
            string resNumberPattern = @"<a href=""http:\/\/www\.nashville\.gov\/mc\/resolutions\/term_2015_2019\/rs2016_(?<num>.*?)\.htm"">";
            Regex resNumberRgx = new Regex(resNumberPattern);
            MatchCollection resNumberMatch = resNumberRgx.Matches(indexHTML);
            string resNumber = resNumberMatch[0].Groups["num"].Value;
            int highest = Convert.ToInt32(resNumber);
            latestResolutionNumber = highest - 77; // 76 Reflects the number of Ords from the previous year
        }
        public Resolution[] resolutionScraper()
        {
            WebClient client = new WebClient();
            highestResNumCollector();
            Resolution[] scrapedResolutions = new Resolution[latestResolutionNumber];
            for (var i = 77; i < latestResolutionNumber + 1; i++)
            {
                Resolution resolution = new Resolution();
                string rawHtml = client.DownloadString($"http://www.nashville.gov/mc/resolutions/term_2015_2019/rs2016_{i}.htm");

                resolution.ResNumber = i;

                string bodyTextPattern = @"<p class=""LEGISLATION"">(?<body>.)*<\/p>";
                Regex bodyTextRgx = new Regex(bodyTextPattern);
                MatchCollection bodyTextMatch = bodyTextRgx.Matches(rawHtml);
                string bodyText = "";
                for (var j = 0; j < bodyTextMatch.Count; j++)
                {
                    string match = bodyTextMatch[j].ToString();
                    bodyText += match;
                }
                if (bodyText == "")
                {
                    string altBodyTextPattern = @"<p><font\ssize=""2""(.*)?<\/p>";
                    Regex altBodyTextRgx = new Regex(altBodyTextPattern);
                    MatchCollection altBodyTextMatch = altBodyTextRgx.Matches(rawHtml);
                    for (var k = 0; k < altBodyTextMatch.Count; k++)
                    {
                        string altMatch = altBodyTextMatch[k].ToString();
                        bodyText += altMatch;
                    }
                }
                resolution.Body = bodyText;

                string captionPattern = @"<p class=""SUMMARY"">.*\s\S?(?<summary>.*?)<\/p>";
                Regex captionRgx = new Regex(captionPattern);
                Match captionMatch = captionRgx.Match(rawHtml);
                string summary = captionMatch.Groups["summary"].Value;
                if (summary == "")
                {
                    string altCaptionPattern = @"<p\salign=""center"">\s?(?<summary>.*?)<\/p>";
                    Regex altCaptionRgx = new Regex(altCaptionPattern);
                    Match altCaptionMatch = altCaptionRgx.Match(rawHtml);
                    summary = altCaptionMatch.Groups["summary"].Value;
                }
                if (summary == "")
                {
                    string altCaptionPattern = @"<p><font\ssize=""-1"">(?<summary>.*?)?<\/p>";
                    Regex altCaptionRgx = new Regex(altCaptionPattern);
                    Match altCaptionMatch = altCaptionRgx.Match(rawHtml);
                    summary = altCaptionMatch.Groups["summary"].Value;
                }
                resolution.Caption = summary;

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
                //resolution.Body = exhibitURLs;

                //string statusPattern = @"";
                //Regex statusRgx = new Regex(statusPattern);
                //Match statusMatch = statusRgx.Match(rawHtml);
                //string status = statusMatch.Groups["status"].Value;
                //resolution.CurrentStatus = status;

                //string sponsorPattern = @"Sponsored by: (?<sponsor>.*?)<\/p>";
                //Regex sponsorRgx = new Regex(sponsorPattern);
                //Match sponsorMatch = sponsorRgx.Match(rawHtml);
                //string sponsor = sponsorMatch.Groups["sponsor"].Value; // probably need .Trim() ?? 
                //resolution.Sponsor = List<sponsor>;

                //string codePattern = @"";
                //Regex codeRgx = new Regex(codePattern);
                //Match codeMatch = codeRgx.Match(rawHtml);
                //string codeText = codeMatch.Groups["codes"].Value;
                //resolution.CodeSections = codeText;


                //string historyPattern = @"";
                //Regex historyRgx = new Regex(historyPattern);
                //Match historyMatch = historyRgx.Match(rawHtml);
                //string history = historyMatch.Groups["history"].Value;
                //resolution.History = history;

                //string enactmentDatePattern = @"";
                //Regex enactmentDateRgx = new Regex(enactmentDatePattern);
                //Match enactmentDateMatch = enactmentDateRgx.Match(rawHtml);
                //DateTime enactmentDate = enactmentDateMatch.Groups["name"].Value;
                //resolution.EnactmentDate = enactmentDate;

                scrapedResolutions[i - 77] = resolution;
            }
            return scrapedResolutions;
        }
        //public void billscrapeCleaner()
        //{
        //Ideally this goes in the middle of resolution scrape to clean up the body text. Keep an eye out for bills that include docs/graphs/tables, etc. Need to know how to handle. 
        //}
    }
}