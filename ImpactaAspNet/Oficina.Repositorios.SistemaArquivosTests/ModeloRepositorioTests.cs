using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class ModeloRepositorioTests
    {
        private ModeloRepositorio modeloRepositorio = new ModeloRepositorio();

        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void SelecionarPorIdMarcaTest(int marcaId)
        {
            List<Modelo> modelos = modeloRepositorio.SelecionarPorMarca(marcaId);
            foreach (var modelo in modelos)
            {
                Console.WriteLine($"ID: {modelo.Id} | Nome: {modelo.Nome} | Fabricante: {modelo.Marca.Nome}");
            }
        }

        [TestMethod()]
        [DataRow(3)]
        public void SelecionarPorIdTest(int modeloId)
        {
            Assert.AreEqual(modeloRepositorio.Selecionar(modeloId).Nome, "Fit");
        }
    }
}