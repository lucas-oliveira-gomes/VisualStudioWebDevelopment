using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagensOnLine.Respositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagensOnLine.Dominio;

namespace ViagensOnLine.Respositorios.SqlServer.Tests
{
    [TestClass()]
    public class ViagensOnlineDbContextTests
    {
        private readonly ViagensOnlineDbContext db = new ViagensOnlineDbContext();

        [TestMethod()]
        public void InserirTest()
        {
            var destino = new Destino
            {
                Cidade = "Paris",
                Nome = "Paris",
                Pais = "França",
                NomeImagem = "Franca.png"
            };

            db.Destinos.Add(destino);
            db.SaveChanges();
        }

        [TestMethod]
        public void AtualizarTeste()
        {
            var destino = db.Destinos.Find(1);
            destino.Cidade = "Quebec";
            destino.Nome = "Quebec";

            db.SaveChanges();

            var destino2 = db.Destinos.Find(1);

            Assert.AreEqual(destino2.Cidade, "Quebec");
        }

        [TestMethod]
        public void ExcluirTeste()
        {
            var destino = db.Destinos.Find(1);
            db.Destinos.Remove(destino);
            db.SaveChanges();
            destino = db.Destinos.Find(1);
            Assert.IsNull(destino);
        }
    }
}