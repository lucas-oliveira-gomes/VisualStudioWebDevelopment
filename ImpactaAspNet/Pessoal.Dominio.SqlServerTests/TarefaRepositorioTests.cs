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
    }
}