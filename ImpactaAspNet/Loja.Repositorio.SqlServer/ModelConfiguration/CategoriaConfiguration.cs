﻿using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorio.SqlServer.ModelConfiguration
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}