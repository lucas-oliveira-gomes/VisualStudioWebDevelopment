using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Configuration.ConfigurationManager;
using static System.AppDomain;
using static System.IO.Path;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class CorRepositorio
    {
        //TODO: implementar método de extensão
        private readonly string caminhoArquivo = Combine(CurrentDomain.BaseDirectory, AppSettings["caminhoArquivoCor"]);
        
        //TODO: OO -- Polimorfismo por sobrecarga;
        public List<Cor> Selecionar()
        {
            var cores = new List<Cor>();
            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                var cor = new Cor();
                cor.Id = Convert.ToInt32(linha.Substring(0, 5));
                cor.Nome = linha.Substring(5);
                cores.Add(cor);
            }
            return cores;
        }

        public Cor Selecionar(int id)
        {
            Cor cor = null;
            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                var linhaId = Convert.ToInt32(linha.Substring(0, 5));
                if (linhaId == id)
                {
                    cor = new Cor();
                    cor.Id = linhaId;
                    cor.Nome = linha.Substring(5);
                    break;
                }
            }
            return cor;
        }
    }
}
