using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Council_Tracker.Models
{
    public class CouncilMember
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Office { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PhotoURL { get; set; }
        public List<string> Occupation { get; set; }
        public List<string> Family { get; set; }
        public List<string> Education { get; set; }
        public List<string> Awards { get; set; }
        public List<string> Experience { get; set; }
        public List<string> Organizations { get; set; }
    }
}