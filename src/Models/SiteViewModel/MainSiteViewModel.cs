using Biberg.MyPortfolio.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public List<ProjectType> ProjectTypes { get; set; }
        //Projects
        public Contact Contacts { get; set; }
    }
}
