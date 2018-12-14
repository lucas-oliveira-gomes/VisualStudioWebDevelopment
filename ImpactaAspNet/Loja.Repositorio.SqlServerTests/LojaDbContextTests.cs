using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorio.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Loja.Dominio;
using System.Data.Entity;

namespace Loja.Repositorio.SqlServer.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private readonly LojaDbContext db = new LojaDbContext();

        public LojaDbContextTests()
        {
            db.Database.Log = LogarQuery;
        }

        private void LogarQuery(string query)
        {
            Debug.WriteLine(query);
        }

        [TestMethod()]
        public void InserirCategoriaTeste()
        {
            var categoria = new Categoria();

            categoria.Nome = "Informatica";


            db.Categorias.Add(categoria);
            db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoTeste()
        {
            var produto = new Produto();

            produto.Nome = "Caneta Bic";
            produto.Preco = 1.99m;
            produto.Estoque = 8;
            produto.Categoria = db.Categorias.Find(1);

            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoComNovaCategoriaTeste()
        {
            var produto = new Produto();

            produto.Nome = "Desodorante";
            produto.Preco = 22.30m;
            produto.Estoque = 3;
            produto.Categoria = new Categoria { Nome = "Perfumaria" };

            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        [TestMethod]
        public void EditarProdutoTeste()
        {

            var produto = db.Produtos.
                Where(p => p.Nome == "Caneta Bic").
                FirstOrDefault();

            produto.Preco = 50.90m;
            produto.Categoria = db.Categorias.Find(2);
            produto.Nome = "Perfume";

            //db.Produtos.Add(produto);
            db.SaveChanges();

        }

        [TestMethod]
        public void ExcluirProdutoTeste()
        {
            var produto = db.Produtos
                .Where(p => p.Categoria.Nome == "Informatica")
                .ToList();

            db.Produtos.RemoveRange(produto);
            db.SaveChanges();

            Assert.IsFalse(db.Produtos.Any(p => p.Categoria.Nome == "Informatica"));
        }

        [TestMethod]
        public void LazyLoadDesligadoTeste()
        {
            var produto = db.Produtos.SingleOrDefault(p => p.Id == 4);

            Assert.IsNull(produto.Categoria);

        }

        [TestMethod]
        public void IncludeTeste()
        {
            var produto = db.Produtos.Include(p => p.Categoria)
                .SingleOrDefault(p => p.Id == 4);

            Console.WriteLine(produto.Categoria.Nome);

        }

        [TestMethod]
        [DataRow(3)]
        public void QueryableTeste(int estoque)
        {
            var query = db.Produtos.Where(p => p.Preco > 40);

            if (estoque > 0)
            {
                query = query.Where(p => p.Estoque >= estoque);
            }

            query.OrderByDescending(p => p.Preco);

            var primeiro = query.FirstOrDefault();
            var ultimo = query.AsEnumerable().LastOrDefault();
            var unico = query.SingleOrDefault();
            var todos = query.ToList();

            
        }

    }
}