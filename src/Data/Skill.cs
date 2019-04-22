using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Data
{
    [Table("Skills")]
    public class Skill
    {
        [Key]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Campo nome obrigatório!")]
        [MaxLength(100)]
        [Display(Name = "Habilidade")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres!")]
        [Required(ErrorMessage = "Campo descrição obrigatório!")]
        [Display(Name = "Descrição")]
        public string ShortDescription { get; set; }

        [Display(Name = "Pontuação")]
        public Int16? Score { get; set; }
    }
}
