using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyOwnBirth.Models;

namespace MyOwnBirth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<ProjetosCategorias> ProjetosCategorias { get; set; }
    }
}
