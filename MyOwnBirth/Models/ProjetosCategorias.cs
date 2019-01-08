using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnBirth.Models
{
    public class ProjetosCategorias
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public int ProjetoID { get; set; }
        public Projeto Projeto { get; set; }
    }
}
