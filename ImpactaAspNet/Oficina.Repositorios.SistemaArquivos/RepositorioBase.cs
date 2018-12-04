using static System.Configuration.ConfigurationManager;
using static System.AppDomain;
using static System.IO.Path;
namespace Oficina.Repositorios.SistemaArquivos
{
    public class RepositorioBase
    {
        protected string ObterCaminhoCompleto(string caminhoParcial)
        {
            return Combine(CurrentDomain.BaseDirectory, AppSettings[caminhoParcial]);
        }
    }
}