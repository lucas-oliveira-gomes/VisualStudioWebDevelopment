using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorio.SqlServer.ModelConfiguration
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            Property(p => p.Date).IsRequired();

            HasRequired(p => p.Cliente);
        }
    }
}