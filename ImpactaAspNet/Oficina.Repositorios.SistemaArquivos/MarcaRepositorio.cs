using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Configuration.ConfigurationManager;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class MarcaRepositorio
    {
        //private string caminhoArquivo = ConfigurationManager.AppSettings["caminhoArquivoMarca"];

        private string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                AppSettings["caminhoArquivoMarca"]);

        public List<Marca> Selecionar()
        {
            var marcas = new List<Marca>();

            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                var propriedades = linha.Split('|');
                var marca = new Marca();

                marca.Id = Convert.ToInt32(propriedades[0]);
                marca.Nome = propriedades[1];

                marcas.Add(marca);
            }

            return marcas;
        }

        public Marca Selecionar(int id)
        {
            Marca marca = null;

            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                var propriedades = linha.Split('|');
                var linhaId = propriedades[0];

                if (Convert.ToUInt32(linhaId) == id)
                {

                    marca = new Marca();
                    marca.Id = Convert.ToInt32(propriedades[0]);
                    marca.Nome = propriedades[1];

                    break;

                }

            }

            return marca;

        }
    
    }
}
