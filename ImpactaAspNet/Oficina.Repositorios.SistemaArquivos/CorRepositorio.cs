using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.IO;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class CorRepositorio : RepositorioBase 
    {
        //const string caminhoArquivo = @"Dados\Cor.txt";

        //ToDo: implementar metodo de extensao
        private string caminhoArquivo;

        public CorRepositorio()
        {
            caminhoArquivo = ObterCaminhoCompleto("caminhoArquivoCor");
        }

        //ToDo: OO - Polimorfismo por sobrecarga.
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
                var linhaId = linha.Substring(0, 5);

                if(Convert.ToUInt32(linhaId) == id)
                {
                    
                    cor = new Cor();
                    cor.Id = Convert.ToInt32(linha.Substring(0, 5));
                    cor.Nome = linha.Substring(5);

                    break;

                }

            }

            return cor;
        }

    }
}
