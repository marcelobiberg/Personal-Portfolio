using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biberg.MyPortfolio.Data
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public Guid ID { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        [Required(ErrorMessage = "Campo título obrigatório!")]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Campo descrição obrigatório!")]
        [Column(TypeName = "ntext")]
        [MaxLength(600, ErrorMessage = "Máximo 600 caracteres!")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres!")]
        [Display(Name = "Introdução")]
        public string ShortDescription { get; set; }

        [MaxLength(150)]
        public string ImagePath { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres!")]
        [Display(Name = "Url do projeto")]
        public string UrlProject { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        [Display(Name = "Github")]
        public string UrlGithub { get; set; }
    }
}
