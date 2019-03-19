using Biberg.MyPortfolio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biberg.MyPortfolio.Models
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Título obrigatório")]
        [Display(Name = "Título")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        [MaxLength(600, ErrorMessage = "Máximo 600 caracteres!")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres!")]
        [Display(Name = "Curta descrição")]
        public string ShortDescription { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres!")]
        [Display(Name = "Imagem")]
        public string ImagePath { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres!")]
        [Display(Name = "Url do projeto")]
        public string UrlProject { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        [Display(Name = "Url do Github")]
        public string UrlGithub { get; set; }


        //Properties navigations
        [ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual string ApplicationUserID { get; set; }

        [ForeignKey("ProjectTypesID")]
        [Display(Name = "Categoria do projeto")]
        public virtual ProjectTypes ProjectTypes { get; set; }
        public virtual int ProjectTypesID { get; set; }
    }
}
