using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pessoal.Dominio.Entidades;
using Pessoal.Repositorio.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Repositorio.SqlServer.Tests
{
    [TestClass()]
    public class TarefaRepositorioTests
    {
        private readonly TarefaRepositorio repositorio = new TarefaRepositorio();

        [TestMethod()]
        public void InserirTest()
        {
            Tarefa tarefa = new Tarefa();

            tarefa.Nome = "Passar Roupa";
            tarefa.Concluida = true;
            tarefa.Observacoes = "Tarefa 1";
            tarefa.Prioridade = Prioridade.Alta;

            tarefa.Id = repositorio.Inserir(tarefa);

            Assert.AreNotEqual(tarefa.Id, 0);

        }

        [TestMethod()]
        public void AtualizarTest()
        {
            Tarefa tarefa = new Tarefa();

            tarefa.Id = 1;
            tarefa.Nome = "Limpar Casa";
            tarefa.Concluida = false;
            tarefa.Observacoes = "Tarefa 2";
            tarefa.Prioridade = Prioridade.Media;

            repositorio.Atualizar(tarefa);

        }

        [TestMethod()]
        public void SelecionarTest()
        {

            foreach (var tarefa in repositorio.Selecionar())
            {
                Console.WriteLine($"{tarefa.Id} - {tarefa.Nome} - {tarefa.Observacoes} - {tarefa.Prioridade} - {tarefa.Concluida} ");

            }

        }

        [TestMethod]
        public void ExcluirTest()
        {
            repositorio.Excluir(1);

            Assert.IsNull(repositorio.Selecionar(1));
        }
    }
}