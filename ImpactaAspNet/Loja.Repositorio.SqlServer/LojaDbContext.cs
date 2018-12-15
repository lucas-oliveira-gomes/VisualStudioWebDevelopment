using Loja.Dominio;
using Loja.Repositorio.SqlServer.Migrations;
using Loja.Repositorio.SqlServer.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Repositorio.SqlServer
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext() : base("lojaSqlServer")
        {
            //Database.SetInitializer(new LojaDbInitializer()); //pag. 191.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LojaDbContext, Configuration>());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new PedidoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoImagemConfiguration());

            //#region Produto

            //#endregion
        }

        public System.Data.Entity.DbSet<Loja.Dominio.ProdutoImagem> ProdutoImagems { get; set; }
    }
}
