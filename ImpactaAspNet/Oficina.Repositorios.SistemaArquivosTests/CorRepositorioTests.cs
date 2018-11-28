using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class CorRepositorioTests
    {
        CorRepositorio corRepositorio = new CorRepositorio();
        [TestMethod()]
        public void SelecionarTest()
        {
            var cores = corRepositorio.Selecionar();
            foreach (var cor in cores)
            {
                Console.WriteLine($"{cor.Id} : {cor.Nome}");
            }
        }

        [TestMethod()]
        public void SelecionarCorPorId()
        {
            var cor = corRepositorio.Selecionar(2);
            Assert.IsTrue("Azul".Equals(cor.Nome));

            var corNula = corRepositorio.Selecionar(6);
            Assert.IsNull(corNula);
        }
    }
}