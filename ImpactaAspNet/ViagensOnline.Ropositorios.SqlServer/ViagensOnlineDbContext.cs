using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagensOnline.Dominio;
using ViagensOnline.Ropositorios.SqlServer.Migrations;

namespace ViagensOnline.Ropositorios.SqlServer
{
    public class ViagensOnlineDbContext : DbContext
    {
        // DbContext é um Unit of Work
        public ViagensOnlineDbContext() : base("viagensOnlineSqlServer")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ViagensOnlineDbContext, Configuration>());
        }

        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
