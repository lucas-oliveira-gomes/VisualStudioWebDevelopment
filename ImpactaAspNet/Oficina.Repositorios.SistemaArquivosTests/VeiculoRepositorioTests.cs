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
        ModeloRepositorio modeloRepositorio = new ModeloRepositorio();
        CorRepositorio corRepositorio = new CorRepositorio();
        VeiculoRepositorio veiculoRepositorio = new VeiculoRepositorio();
        [TestMethod()]
        public void InserirVeiculoTest()
        {
            Cor cor = corRepositorio.Selecionar(1);
            Modelo modelo = modeloRepositorio.Selecionar(2);
            Veiculo veiculo = new Veiculo();
            veiculo.Placa = "abc1234";
            veiculo.Observacao = "Primeiro Veiculo";
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Combustivel = Combustivel.Gasolina;
            veiculo.Cambio = Cambio.Automatico;
            veiculo.Ano = 2014;
            veiculoRepositorio.Inserir(veiculo);
        }
    }
}