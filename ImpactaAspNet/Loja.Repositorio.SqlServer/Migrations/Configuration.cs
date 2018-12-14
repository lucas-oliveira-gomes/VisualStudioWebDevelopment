namespace Loja.Repositorio.SqlServer.Migrations
{
    using Loja.Dominio;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Loja.Repositorio.SqlServer.LojaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Loja.Repositorio.SqlServer.LojaDbContext";
        }

        protected override void Seed(LojaDbContext context)
        {
            //context.Database.ExecuteSqlCommand("");

            if (!context.Produtos.Any())
            {
                context.Produtos.AddRange(ObterProdutos());
                context.SaveChanges();
            }
        }

        private IEnumerable<Produto> ObterProdutos()
        {

            var grampeador = new Produto();
            grampeador.Categoria = new Categoria { Nome = "Drogaria" };
            grampeador.Nome = "Insulina";
            grampeador.Preco = 59m;
            grampeador.Estoque = 454;

            var pendrive = new Produto();
            pendrive.Categoria = new Categoria { Nome = "Informatica" };
            pendrive.Nome = "Pen Drive";
            pendrive.Preco = 100m;
            pendrive.Estoque = 250;

            return new List<Produto> { grampeador, pendrive };
        }

    }
}
