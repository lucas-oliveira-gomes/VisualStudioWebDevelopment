using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pessoal.Dominio.Entidades;
using Pessoal.Dominio.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Dominio.SqlServer.Tests
{
    [TestClass()]
    public class TarefaRepositorioTests
    {
        private readonly TarefaRepositorio repositorio = new TarefaRepositorio();
        [TestMethod()]
        public void InserirTest()
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Prioridade = Prioridade.Baixa;
            tarefa.Observacoes = "Tarefa 1";
            tarefa.Nome = "Primeira Tarefa";
            tarefa.Concluida = false;
            tarefa.Id = repositorio.Inserir(tarefa);

            Assert.IsTrue(tarefa.Id > 0);
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            Tarefa tarefa = new Tarefa
            {
                Prioridade = Prioridade.Baixa,
                Observacoes = "Tarefa 1 Atualizada",
                Nome = "Primeira Tarefa Atualizada",
                Concluida = true,
                Id = 1
            };
            repositorio.Atualizar(tarefa);
        }

        [TestMethod()]
        public void SelecionarTest()
        {
            var tarefas = repositorio.Selecionar();

            foreach (var tarefa in tarefas)
            {
                Console.WriteLine($"{tarefa.Id} - {tarefa.Nome} - {tarefa.Concluida} - {tarefa.Observacoes} - {tarefa.Prioridade}");
            }
        }

        [TestMethod()]
        public void DeletarTest()
        {
            Tarefa tarefa = new Tarefa
            {
                Prioridade = Prioridade.Alta,
                Observacoes = "Esta é uma tarefa de testes",
                Nome = "Tarefa de testes",
                Concluida = true
            };

            var tarefaId = repositorio.Inserir(tarefa);

            var tarefa2 = repositorio.Selecionar(tarefaId);

            Assert.IsNotNull(tarefa2);
            Assert.AreEqual(tarefa2.Id, tarefaId);

            repositorio.Deletar(tarefaId);

            tarefa2 = repositorio.Selecionar(tarefaId);

            Assert.IsNull(tarefa2);
        }
    }
}