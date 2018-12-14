using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Configuration.ConfigurationManager;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class VeiculoRepositorio
    {
        private readonly string caminhoArquivo;
        private XDocument arquivoXml;

        public VeiculoRepositorio()
        {
            caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                AppSettings["caminhoArquivoVeiculo"]);
        }

        public void Inserir<T>(T veiculo) where T:Veiculo
        {
            arquivoXml = XDocument.Load(caminhoArquivo);

            var registro = new StringWriter();

            new XmlSerializer(typeof(T)).Serialize(registro, veiculo);

            arquivoXml.Root.Add(XElement.Parse(registro.ToString()));

            arquivoXml.Save(caminhoArquivo);
        }
    }
}
