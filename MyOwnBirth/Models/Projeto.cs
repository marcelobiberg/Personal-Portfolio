using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnBirth.Models
{
    public class Projeto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImgCarousel1 { get; set; }
        public string ImgCarousel2 { get; set; }
        public string ImgCarousel3 { get; set; }
        public bool IsActive { get; set; }

        public ICollection<ProjetosCategorias> Categories { get; set; }
    }
}
