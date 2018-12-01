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
            var veiculoPasseio = new VeiculoPasseio();
            veiculoPasseio.Placa = "abc1234";
            veiculoPasseio.Observacao = "Primeiro Veiculo";
            veiculoPasseio.Cor = cor;
            veiculoPasseio.Modelo = modelo;
            veiculoPasseio.Combustivel = Combustivel.Gasolina;
            veiculoPasseio.Cambio = Cambio.Automatico;
            veiculoPasseio.Ano = 2014;
            veiculoPasseio.Carroceria = Carroceria.Hatch;
            veiculoRepositorio.Inserir(veiculoPasseio);
        }
    }
}