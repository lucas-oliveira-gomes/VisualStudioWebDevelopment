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
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["pessoalSqlServer"].ConnectionString;
        public void Atualizar(Tarefa Tarefa)
        {
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                using (var comando = new SqlCommand("TarefaAtualizar", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(Tarefa).ToArray());
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdTarefa)
        {
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                using (var comando = new SqlCommand("TarefaExcluir", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@ID", IdTarefa);
                    comando.ExecuteNonQuery();
                }
            }
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
            if (tarefa.Id > 0)
            {
                parametros.Add(new SqlParameter("@ID", tarefa.Id));
            }
            parametros.Add(new SqlParameter("@CONCLUIDA", tarefa.Concluida));
            parametros.Add(new SqlParameter("@NOME", tarefa.Nome));
            parametros.Add(new SqlParameter("@OBSERVACOES", tarefa.Observacoes));
            parametros.Add(new SqlParameter("@PRIORIDADE", tarefa.Prioridade));
            return parametros;
        }

        public Tarefa Selecionar(int IdTarefa)
        {
            Tarefa tarefa = null;
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                using (var comando = new SqlCommand("TarefaSelecionar", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@ID", IdTarefa);
                    using (var registro = comando.ExecuteReader())
                    {
                        if (registro.Read())
                        {
                            tarefa = Mapear(registro);
                        }
                    }
                }
            }

            return tarefa;
        }

        public List<Tarefa> Selecionar()
        {
            var tarefas = new List<Tarefa>();
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                using (var comando = new SqlCommand("TarefaSelecionar", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (var registro = comando.ExecuteReader())
                    {
                        while (registro.Read())
                        {
                            tarefas.Add(Mapear(registro));
                        }
                    }
                }
            }

            return tarefas;
        }

        private Tarefa Mapear(SqlDataReader registro)
        {
            var tarefa = new Tarefa
            {
                Id = Convert.ToInt32(registro["ID"]),
                Concluida = Convert.ToBoolean(registro["CONCLUIDA"]),
                Nome = registro["NOME"].ToString(),
                Observacoes = Convert.ToString(registro["OBSERVACOES"]),
                Prioridade = (Prioridade)registro["PRIORIDADE"]
            };
            return tarefa;
        }
    }
}
