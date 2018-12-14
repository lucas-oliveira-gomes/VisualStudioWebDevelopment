using System;
using System.Collections.Generic;
using System.Data.Entity;
using Loja.Dominio;

namespace Loja.Repositorio.SqlServer
{
    internal class LojaDbInitializer : DropCreateDatabaseIfModelChanges<LojaDbContext>
    {
        protected override void Seed(LojaDbContext context)
        {
            context.Produtos.AddRange(ObterProdutos());
            context.SaveChanges();
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

            

            return new List<Produto> {grampeador,pendrive};
        }
    }
}