using Oficina.Dominio;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class VeiculoRepositorio : RepositorioBase
    {
        private readonly string caminhoArquivo;
        private XDocument arquivoXml;

        public VeiculoRepositorio()
        {
            caminhoArquivo = ObterCaminhoCompleto("caminhoArquivoVeiculo");
        }


        public void Inserir<T>(T veiculo) where T : Veiculo
        {
            arquivoXml = XDocument.Load(caminhoArquivo);
            var registro = new StringWriter();
            new XmlSerializer(typeof(T)).Serialize(registro, veiculo);
            arquivoXml.Root.Add(XElement.Parse(registro.ToString()));
            arquivoXml.Save(caminhoArquivo);
        }
    }
}
