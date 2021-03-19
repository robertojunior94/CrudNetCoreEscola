using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
using CrudNetCoreEscola.Model;

namespace CrudNetCoreEscola.Repository
{
    public class EscolaContext : DbContext
    {
        public static EscolaContext Create()
        {
            return new EscolaContext();
        }

        public EscolaContext() : base(@"Data Source=JUNIORPC\SQLEXPRESS;Initial Catalog=Escola;Integrated Security=True")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Escola> Escola { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Aluno> Aluno { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


        }
    }
}
