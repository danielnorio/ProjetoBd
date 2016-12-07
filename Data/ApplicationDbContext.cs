using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoDeBancoDeDados.Models;

namespace ProjetoDeBancoDeDados.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Unidade> Unidade { get; set; }

        public DbSet<Funcionario> Funcionario { get; set; }

        public DbSet<Dependente> Dependente { get; set; }

        public DbSet<Seguradora> Seguradora { get; set; }

        public DbSet<PlanoOdontologico> PlanoOdontologico { get; set; }

        public DbSet<PlanoSaude> PlanoSaude { get; set; }

        public DbSet<SeguroAcidente> SeguroAcidente { get; set; }
    }
}
