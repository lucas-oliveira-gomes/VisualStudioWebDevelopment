using System;
using System.IO;
using static System.Configuration.ConfigurationManager;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class RepositorioBase
    {

        protected string ObterCaminhoCompleto(string caminho)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            AppSettings[caminho]);
        }

    }
}