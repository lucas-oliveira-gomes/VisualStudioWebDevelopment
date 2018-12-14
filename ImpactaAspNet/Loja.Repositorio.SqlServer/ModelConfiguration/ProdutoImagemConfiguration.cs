using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorio.SqlServer.ModelConfiguration
{
    internal class ProdutoImagemConfiguration : EntityTypeConfiguration<ProdutoImagem>
    {
        public ProdutoImagemConfiguration()
        {
            HasKey(pi => pi.ProdutoId);

            Property(pi => pi.ProdutoId)
                    .HasColumnName("Produto_Id");

            Property(c => c.ContentType)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}