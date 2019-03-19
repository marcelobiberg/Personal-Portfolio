using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biberg.MyPortfolio.Models
{
    public class ProjectTypes
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tipo obrigatório")]
        [Display(Name = "Tipo Projeto")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        public string Name { get; set; }


        //Properties navigations
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
        public virtual List<Project> Projects { get; set; }
    }
}
