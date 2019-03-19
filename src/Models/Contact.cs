using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biberg.MyPortfolio.Models
{
    [NotMapped]
    public class Contact
    {
        [Display(Name ="Nome")]
        [Required(ErrorMessage ="Nome obrigatório!")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail obrigatório!")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Telefone obrigatório!")]
        public string Phone { get; set; }

        [Display(Name = "Comentário")]
        public string Feedback { get; set; }

    }
}
