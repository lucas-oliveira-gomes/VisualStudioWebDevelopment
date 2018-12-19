using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Repositorios.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.WebApi.Tests
{
    [TestClass()]
    public class ProductRepositorioTests
    {
        private readonly ProductRepositorio repositorio = new ProductRepositorio();
        [TestMethod()]
        public void PostTest()
        {
            var product = new ProductViewModel()
            {
                ProductName = "Água Mineral",
                UnitPrice = 4.68m,
                Discontinued = false,
                QuantityPerUnit = "4 units per Box"
            };

            var reponse = repositorio.Post(product).Result;
            Console.WriteLine(reponse.ProductID);
        }

        [TestMethod()]
        public void PutTest()
        {
            var product = new ProductViewModel()
            {
                ProductID = 81,
                ProductName = "Água Mineral",
                UnitPrice = 12.68m,
                Discontinued = false,
                QuantityPerUnit = "45 units per Box"
            };
            repositorio.Put(product).Wait();
            var response = repositorio.Get(81).Result;

            Assert.IsTrue(response.UnitPrice == 12.68m);
        }

        [TestMethod()]
        public void GetTest()
        {
            var products = repositorio.Get().Result;
            Assert.IsTrue(products.Count > 0);
            Console.WriteLine(products.Count);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var product = new ProductViewModel()
            {
                ProductName = "Test Product",
                UnitPrice = 4.68m,
                Discontinued = false,
                QuantityPerUnit = "4 units per Box"
            };

            var reponse = repositorio.Post(product).Result;


            var id = reponse.ProductID;
            repositorio.Delete(id).Wait();
            var products = repositorio.Get().Result;

            Assert.IsFalse(products.Where(p => p.ProductID == id).Any());
        }
    }
}