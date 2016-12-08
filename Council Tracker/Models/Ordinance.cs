using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Council_Tracker.Models
{
    public class Ordinance
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int OrdNumber { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string Caption { get; set; }
        public List<CouncilMember> Sponsor { get; set; }
        public List<int> CodeSections { get; set; }
        public string CurrentStatus { get; set; }
        public Dictionary<string, DateTime> History { get; set; }
        public DateTime EnactmentDate { get; set; }
        public string ExhibitURL { get; set; }
    }
}