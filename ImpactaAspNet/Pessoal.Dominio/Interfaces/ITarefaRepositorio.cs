using Pessoal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Dominio.Interfaces
{
    public interface ITarefaRepositorio
    {
        int Inserir(Tarefa Tarefa);

        Tarefa Selecionar(int IdTarefa);

        List<Tarefa> Selecionar();

        void Atualizar(Tarefa Tarefa);

        void  Deletar(int IdTarefa);
    }
}
