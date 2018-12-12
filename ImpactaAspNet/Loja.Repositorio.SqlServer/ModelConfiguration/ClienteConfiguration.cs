using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorio.SqlServer.ModelConfiguration
{
    internal class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}