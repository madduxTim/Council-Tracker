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
            Ordinance[] scrapedOrds = new Ordinance[6];
            for (var i = 100; i < 105; i++)
            {
                Ordinance ordinance = new Ordinance();
                string rawHtml = client.DownloadString($"http://www.nashville.gov/mc/ordinances/term_2015_2019/bl2016_{i}.htm");

                string ordNumberPattern = @"";
                Regex ordNumberRgx = new Regex(ordNumberPattern);
                Match ordNumberMatch = ordNumberRgx.Match(rawHtml);
                string ordNumber = ordNumberMatch.Groups["ordNumber"].Value;
                ordinance.OrdNumber = Convert.ToInt32(ordNumber);

                string bodyTextPattern = @"";
                Regex bodyTextRgx = new Regex(bodyTextPattern);
                Match bodyTextMatch = bodyTextRgx.Match(rawHtml);
                string bodyText = bodyTextMatch.Groups["body"].Value;
                ordinance.Body = bodyText;

                string captionPattern = @"";
                Regex captionRgx = new Regex(captionPattern);
                Match captionMatch = captionRgx.Match(rawHtml);
                string caption = captionMatch.Groups["caption"].Value;
                ordinance.Caption = caption;

                //string sponsorPattern = @"";
                //Regex sponsorRgx = new Regex(sponsorPattern);
                //Match sponsorMatch = sponsorRgx.Match(rawHtml);
                //string sponsor = sponsorMatch.Groups["name"].Value;
                //ordinance.Sponsor = List<sponsor>;

                //string codePattern = @"";
                //Regex codeRgx = new Regex(codePattern);
                //Match codeMatch = codeRgx.Match(rawHtml);
                //string codeText = codeMatch.Groups["codes"].Value;
                //ordinance.CodeSections = codeText;

                string statusPattern = @"";
                Regex statusRgx = new Regex(statusPattern);
                Match statusMatch = statusRgx.Match(rawHtml);
                string status = statusMatch.Groups["status"].Value;
                ordinance.CurrentStatus = status;

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

                string exhibitURLPattern = @"";
                Regex exhibitURLRgx = new Regex(exhibitURLPattern);
                Match exhibitURLMatch = exhibitURLRgx.Match(rawHtml);
                string exhibitURL = bodyTextMatch.Groups["eURL"].Value;
                ordinance.ExhibitURL = exhibitURL;

                scrapedOrds[i - 1] = ordinance;
            }
            return scrapedOrds;
        }
    }
}