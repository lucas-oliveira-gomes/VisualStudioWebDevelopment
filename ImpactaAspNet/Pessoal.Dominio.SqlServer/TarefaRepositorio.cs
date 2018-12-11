using Pessoal.Dominio.Entidades;
using Pessoal.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Dominio.SqlServer
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["pessoalSqlServer"].ConnectionString;
        public void Atualizar(Tarefa Tarefa)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int IdTarefa)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Tarefa Tarefa)
        {
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                using (var comando = new SqlCommand("TarefaInserir", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(Tarefa).ToArray());
                    return (int)comando.ExecuteScalar();
                }
            }
        }

        private List<SqlParameter> Mapear(Tarefa tarefa)
        {
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@CONCLUIDA", tarefa.Concluida));
            parametros.Add(new SqlParameter("@NOME", tarefa.Nome));
            parametros.Add(new SqlParameter("@OBSERVACOES", tarefa.Observacoes));
            parametros.Add(new SqlParameter("@PRIORIDADE", tarefa.Prioridade));
            return parametros;
        }

        public Tarefa Selecionar(int IdTarefa)
        {
            throw new NotImplementedException();
        }

        public List<Tarefa> Selecionar()
        {
            throw new NotImplementedException();
        }
    }
}
