using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Configuration.ConfigurationManager;
using static System.AppDomain;
using static System.IO.Path;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class MarcaRepositorio
    {
        private readonly string caminhoArquivo = Combine(CurrentDomain.BaseDirectory, AppSettings["caminhoArquivoMarca"]);
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
                var linhaId = Convert.ToInt32(propriedades[0]);
                if (linhaId == id)
                {
                    marca = new Marca();
                    marca.Id = linhaId;
                    marca.Nome = propriedades[1];
                    break;
                }
            }
            return marca;
        }
    }
}
