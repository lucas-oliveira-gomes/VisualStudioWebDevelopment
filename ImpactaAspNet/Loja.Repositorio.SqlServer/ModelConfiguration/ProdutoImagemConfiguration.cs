using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorio.SqlServer.ModelConfiguration
{
    public class ProdutoImagemConfiguration : EntityTypeConfiguration<ProdutoImagem>
    {
        public ProdutoImagemConfiguration()
        {
            //ToTable("Nome_Tabela");
            HasKey(pi => pi.ProdutoId);

            Property(pi => pi.ProdutoId)
                .HasColumnName("Produto_Id");

            Property(pi => pi.ContentType)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}