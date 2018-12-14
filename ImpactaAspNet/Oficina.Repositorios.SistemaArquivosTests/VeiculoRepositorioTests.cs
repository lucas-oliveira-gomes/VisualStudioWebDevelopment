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
    public class VeiculoRepositorioTests

    {
        CorRepositorio corRepositorio = new CorRepositorio();
        ModeloRepositorio modeloRepositorio = new ModeloRepositorio();

        [TestMethod()]
        public void InserirTest()
        {
            var veiculo = new VeiculoPasseio();
            var cor = corRepositorio.Selecionar(2);
            var modelo = modeloRepositorio.Selecionar(1);

            //veiculo.Id = 1;
            veiculo.Placa = "AAA1234";
            veiculo.Ano = 2018;
            veiculo.Observacao = "bla bla";
            veiculo.Modelo = modelo;
            veiculo.Cor = cor;
            veiculo.Combustivel = Combustivel.Gasolina;
            veiculo.Cambio = Cambio.Automatico;
            veiculo.Carroceria = Carroceria.Hatch;

            new VeiculoRepositorio().Inserir(veiculo);
        }
    }
}