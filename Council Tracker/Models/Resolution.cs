using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Council_Tracker.Models
{
    public class Resolution
    {
        [Key]
        public int ID { get; set; }
        public int Year { get; set; }
        public int ResNumber { get; set; }
        public string Body { get; set; }
        public string Caption { get; set; }
        public List<CouncilMember> Sponsor { get; set; }
        public List<int> CodeSections { get; set; }
        public string CurrentStatus { get; set; }
        public Dictionary<string, DateTime> History { get; set; }
        public DateTime? EnactmentDate { get; set; }
        public string ExhibitURL { get; set; }
    }
}