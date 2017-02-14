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
        public int numberOf2015Ords = 0;
        public int numberOf2016Ords = 0;
        public int numberOf2017Ords = 0;
        public int highest2015OrdNumber = 0;
        public int highest2016OrdNumber = 0;
        public int highest2017OrdNumber = 0;
        public void highestOrdNumCollector()
        {
            WebClient client = new WebClient();
            string indexHTML = client.DownloadString($"http://www.nashville.gov/Metro-Clerk/Legislative/Ordinances/2015-2019.aspx");
            string ordNumberPattern2015 = @"www.nashville.gov\/mc\/ordinances\/term_2015_2019\/bl[0-9]{4}_[0-9]*.htm"">ORDINANCE\sBL2015-(?<num15>[0-9]*)<\/a>";
            string ordNumberPattern2016 = @"www.nashville.gov\/mc\/ordinances\/term_2015_2019\/bl[0-9]{4}_[0-9]*.htm"">ORDINANCE\sBL2016-(?<num16>[0-9]*)<\/a>";
            string ordNumberPattern2017 = @"www.nashville.gov\/mc\/ordinances\/term_2015_2019\/bl[0-9]{4}_[0-9]*.htm"">ORDINANCE\sBL2017-(?<num17>[0-9]*)<\/a>";
            Regex ordNumberRgx15 = new Regex(ordNumberPattern2015);
            Regex ordNumberRgx16 = new Regex(ordNumberPattern2016);
            Regex ordNumberRgx17 = new Regex(ordNumberPattern2017);
            MatchCollection ordNumberMatch15 = ordNumberRgx15.Matches(indexHTML);
            MatchCollection ordNumberMatch16 = ordNumberRgx16.Matches(indexHTML);
            MatchCollection ordNumberMatch17 = ordNumberRgx17.Matches(indexHTML);
            string ordNumber15 = ordNumberMatch15[0].Groups["num15"].Value;
            string ordNumber16 = ordNumberMatch16[0].Groups["num16"].Value;
            string ordNumber17 = ordNumberMatch17[0].Groups["num17"].Value;
            highest2015OrdNumber = Convert.ToInt32(ordNumber15);
            highest2016OrdNumber = Convert.ToInt32(ordNumber16);
            highest2017OrdNumber = Convert.ToInt32(ordNumber17);
            numberOf2015Ords = highest2015OrdNumber;
            numberOf2016Ords = highest2016OrdNumber - highest2015OrdNumber;
            numberOf2017Ords = highest2017OrdNumber - highest2016OrdNumber;
        }
        public Ordinance[] ordinanceScraper()
        {
            int allYears = numberOf2015Ords + numberOf2016Ords + numberOf2017Ords;
            WebClient client = new WebClient();
            highestOrdNumCollector();
            Ordinance[] scrapedOrds = new Ordinance[numberOf2017Ords];
            for (var k = 541; k < highest2017OrdNumber+1; k++) // 541 IS FIRST 2017 NUMBER
            {
                Ordinance ordinance = new Ordinance();
                string rawHtml = client.DownloadString($"http://www.nashville.gov/mc/ordinances/term_2015_2019/bl2016_{k}.htm"); // REMINDER: THEY HAVEN'T CHANGED THE URL TO bl2017 YET!
                if (rawHtml.Contains("Sorry, we couldn't find the page you were looking for..."))
                {
                    rawHtml = client.DownloadString($"http://www.nashville.gov/mc/ordinances/term_2015_2019/bl2017_{k}.htm");
                }
                ordinance.OrdNumber = k;

                ordinance.Year = 2017; 

                string captionPattern = @"<\/font><\/b>(?<caption>An ordinance.*?)<\/p>";
                Regex captionRgx = new Regex(captionPattern);
                Match captionMatch = captionRgx.Match(rawHtml);
                string caption = captionMatch.Groups["caption"].Value;
                ordinance.Caption = caption;

                string bodyTextPattern = @"<p class=""ordinancecontent"">(?<body>.)*<\/p>";
                Regex bodyTextRgx = new Regex(bodyTextPattern);
                MatchCollection bodyTextMatch = bodyTextRgx.Matches(rawHtml);
                string bodyText = "";
                for (var j = 0; j < bodyTextMatch.Count; j++)
                {
                    string match = bodyTextMatch[j].ToString();
                    bodyText += match;
                }
                //going to have to switch this back at some point and create a new column in the models.
                //ordinance.Body = rawHtml;
                ordinance.Body = bodyText;

                //string sponsorPattern = @"Sponsored by: (?<sponsor>.*?)<\/p>";
                //Regex sponsorRgx = new Regex(sponsorPattern);
                //MatchCollection sponsorMatch = sponsorRgx.Matches(rawHtml);
                //string sponsorString = sponsorMatch[0].ToString();
                //SQL matching with council member. Send to list. 
                //ordinance.Sponsor = blah. 

                scrapedOrds[k - 541] = ordinance;
            }
            //for (var j = 99; j < highest2016OrdNumber+1; j++) // 99 IS FIRST 2016 NUMBER
            //{
            //    Ordinance ordinance = new Ordinance();
            //    ordinance.OrdNumber = j;
            //    ordinance.Body = client.DownloadString($"http://www.nashville.gov/mc/ordinances/term_2015_2019/bl2016_{j}.htm");
            //    scrapedOrds[j - 99] = ordinance;
            //}
            //for (var i = 1; i < highest2015OrdNumber+1; i++)
            //{
            //    Ordinance ordinance = new Ordinance();
            //    ordinance.OrdNumber = i;
            //    ordinance.Body = client.DownloadString($"http://www.nashville.gov/mc/ordinances/term_2015_2019/bl2015_{i}.htm");
            //    scrapedOrds[i-1] = ordinance;
            //}
            return scrapedOrds;
        }
        //public void billscrapeCleaner()
        //{
            //Ideally this goes in the middle of ordinance scrape to clean up the body text. Keep an eye out for bills that include docs/graphs/tables, etc. Need to know how to handle. 
        //}
    }
}

//public Ordinance[] ordinanceScraper()
//{
//    WebClient client = new WebClient();
//    highestOrdNumCollector();
//    Ordinance[] scrapedOrds = new Ordinance[numberOf2016Ords];
//    for (var i = 99; i < numberOf2016Ords + 99; i++)
//    {
//        Ordinance ordinance = new Ordinance();
//        string rawHtml = client.DownloadString($"http://www.nashville.gov/mc/ordinances/term_2015_2019/bl2016_{i}.htm");

//        ordinance.OrdNumber = i;

//        string bodyTextPattern = @"<p class=""ordinancecontent"">(?<body>.)*<\/p>";
//        Regex bodyTextRgx = new Regex(bodyTextPattern);
//        MatchCollection bodyTextMatch = bodyTextRgx.Matches(rawHtml);
//        //List<string> textsList = new List<string>();
//        string bodyText = "";
//        for (var j = 0; j < bodyTextMatch.Count; j++)
//        {
//            string match = bodyTextMatch[j].ToString();
//            //textsList.Add(match);
//            bodyText += match;
//        }
//        ordinance.Body = bodyText;

//        string captionPattern = @"<\/font><\/b>(?<caption>An ordinance.*?)<\/p>";
//        Regex captionRgx = new Regex(captionPattern);
//        Match captionMatch = captionRgx.Match(rawHtml);
//        string caption = captionMatch.Groups["caption"].Value;
//        ordinance.Caption = caption;

//        // NEEDS TO BE REFACTORED INTO A DICTIONARY SO THAT IT CAN CONTAIN A STRING URL AND A STRING NAME...
//        //string exhibitURLsPattern = @"<p class=""ordinancecontent""><a href=""(?< body >.)*"">(?<docName>.)*<\/a><\/p>";
//        //Regex exhibitURLsRgx = new Regex(exhibitURLsPattern);
//        //MatchCollection exhibitURLsMatch = exhibitURLsRgx.Matches(rawHtml);
//        ////List<string> textsList = new List<string>();
//        //string exhibitURLs = "";
//        //for (var j = 0; j < exhibitURLsMatch.Count; j++)
//        //{
//        //    string match = exhibitURLsMatch[j].ToString();
//        //    //textsList.Add(match);
//        //    exhibitURLs += match;
//        //}
//        //ordinance.Body = exhibitURLs;

//        //string statusPattern = @"";
//        //Regex statusRgx = new Regex(statusPattern);
//        //Match statusMatch = statusRgx.Match(rawHtml);
//        //string status = statusMatch.Groups["status"].Value;
//        //ordinance.CurrentStatus = status;

//        //string sponsorPattern = @"Sponsored by: (?<sponsor>.*?)<\/p>";
//        //Regex sponsorRgx = new Regex(sponsorPattern);
//        //Match sponsorMatch = sponsorRgx.Match(rawHtml);
//        //string sponsor = sponsorMatch.Groups["sponsor"].Value; // probably need .Trim() ?? 
//        //ordinance.Sponsor = List<sponsor>;

//        //string codePattern = @"";
//        //Regex codeRgx = new Regex(codePattern);
//        //Match codeMatch = codeRgx.Match(rawHtml);
//        //string codeText = codeMatch.Groups["codes"].Value;
//        //ordinance.CodeSections = codeText;


//        //string historyPattern = @"";
//        //Regex historyRgx = new Regex(historyPattern);
//        //Match historyMatch = historyRgx.Match(rawHtml);
//        //string history = historyMatch.Groups["history"].Value;
//        //ordinance.History = history;

//        //string enactmentDatePattern = @"";
//        //Regex enactmentDateRgx = new Regex(enactmentDatePattern);
//        //Match enactmentDateMatch = enactmentDateRgx.Match(rawHtml);
//        //DateTime enactmentDate = enactmentDateMatch.Groups["name"].Value;
//        //ordinance.EnactmentDate = enactmentDate;

//        scrapedOrds[i - 99] = ordinance;
//    }
//    return scrapedOrds;
//}