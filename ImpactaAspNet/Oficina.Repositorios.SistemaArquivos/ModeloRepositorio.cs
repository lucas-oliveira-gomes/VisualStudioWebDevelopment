using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Oficina.Dominio;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class ModeloRepositorio : RepositorioBase
    {
        public ModeloRepositorio()
        {
            arquivoXml = XDocument.Load(ObterCaminhoCompleto("caminhoArquivoModelo"));
        }
        private XDocument arquivoXml;

        private MarcaRepositorio marcaRepositorio = new MarcaRepositorio();

        /// <summary>
        /// Select all available veicles models
        /// </summary>
        /// <param name="marcaId"></param>
        /// <returns></returns>
        public List<Modelo> SelecionarPorMarca(int marcaId)
        {
            List<Modelo> modelos = new List<Modelo>();
            foreach (var elemento in arquivoXml.Descendants("modelo"))
            {
                if (marcaId.ToString().Equals(elemento.Element("marcaId").Value))
                {
                    var modelo = new Modelo();
                    modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                    modelo.Nome = elemento.Element("nome").Value;
                    modelo.Marca = marcaRepositorio.Selecionar(marcaId);
                    modelos.Add(modelo);
                }
            }
            return modelos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="marcaId"></param>
        /// <param name="modeloId"></param>
        /// <returns></returns>
        public Modelo Selecionar(int id)
        {
            Modelo modelo = null;
            foreach (var elemento in arquivoXml.Descendants("modelo"))
            {
                if (id.ToString().Equals(elemento.Element("id").Value))
                {
                    modelo = new Modelo();
                    modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                    modelo.Nome = elemento.Element("nome").Value;
                    modelo.Marca = marcaRepositorio.Selecionar(Convert.ToInt32(elemento.Element("marcaId").Value));
                    break;
                }
            }
            return modelo;
        }
    }
}
