using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biberg.MyPortfolio.Models.SiteViewModel
{
    public class MainSiteViewModel 
    {
        //User
        [Display(Name ="Nome")]
        public string Name { get; set; }
        [Display(Name = "Cargo")]
        public string Role{ get; set; }
        public string AboutDescription { get; set; }

        //Skills
        public List<Skill> Skills { get; set; }

        //Projects
        public List<Project> Projects { get; set; }
        public List<ProjectTypes> ProjectTypes { get; set; }

        //Projects
        public Contact Contacts { get; set; }
    }
}
