using Biberg.MyPortfolio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biberg.MyPortfolio.Models
{
    [Table("Skills")]
    public class Skill
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Habilidade")]
        public string Name { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "Campo descrição obrigatório!")]
        [Display(Name ="Descrição")]
        public string ShortDescription { get; set; }

        [Display(Name ="Pontuação")]
        public Int16? Score { get; set; }


        //Properties navigations
        [ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual string ApplicationUserID { get; set; }
    }
}
