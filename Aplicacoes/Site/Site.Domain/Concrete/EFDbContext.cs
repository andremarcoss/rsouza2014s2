using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.Domain.Entities;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace Site.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Remessa> Remessas { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<Motivo> Motivos { get; set; }
        public DbSet<Parentesco> Parentescos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
