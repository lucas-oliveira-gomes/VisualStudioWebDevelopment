using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorio.SqlServer.ModelConfiguration
{
    internal class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            HasRequired(p => p.Cliente);
            //Property(p => p.Data).IsRequired();
        }
    }
}