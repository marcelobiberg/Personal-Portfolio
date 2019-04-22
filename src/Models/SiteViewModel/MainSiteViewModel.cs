using MyPortfolio.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MyPortfolio.Models.SiteViewModel
{
    public class MainSiteViewModel 
    {
        [Display(Name ="Nome")]
        public string Name { get; set; }
        [Display(Name = "Cargo")]
        public string Role{ get; set; }
        public string AboutDescription { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Project> Projects { get; set; }
        public Contact Contacts { get; set; }
    }
}
