using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorio.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Dominio;
using System.Diagnostics;

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
            var categoria = new Categoria
            {
                Nome = "Informática"
            };
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoTeste()
        {
            var produto = new Produto();
            produto.Nome = "Caneta";
            produto.Preco = 1.99m;
            produto.Estoque = 10;
            produto.Categoria = db.Categorias.Where(c => c.Nome.Equals("Informática")).First();

            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        [TestMethod]
        public void InserirprodutoComNovacategoriaTeste()
        {
            var categoria = new Categoria
            {
                Nome = "Perfumaria"
            };

            var produto = new Produto
            {
                Nome = "Alfazema",
                Preco = 10.99m,
                Estoque = 10,
                Categoria = categoria
            };
            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        [TestMethod]
        public void EditarProdutoTeste()
        {
            var produto = db.Produtos.Where(p => p.Nome.Equals("Caneta")).OrderBy(p => p.Id).First();
            produto.Preco = 18.67m;
            produto.Estoque = 68;
            produto.Categoria = db.Categorias.Where(c => c.Nome.Equals("Categoria 1")).FirstOrDefault();
            produto.Categoria.Nome = "Papelaria";
            db.SaveChanges();
        }

        [TestMethod]
        public void ExcluirProdutoTeste()
        {
            var produto = db.Produtos.Where(p => p.Nome.Equals("Caneta")).First();
            db.Produtos.Remove(produto);
            db.SaveChanges();

            Assert.IsNull(db.Produtos.Select(p => p.Nome.Equals("Papelaria")).Any());
        }
    }
}