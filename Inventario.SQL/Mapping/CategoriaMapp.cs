using Inventario.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.SQL.Mapping
{
    public class CategoriaMapp : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            //name of table
            builder.ToTable(nameof(Categoria));
            //primary key
            builder.HasKey(x => x.IdCategoria);
            //property
            builder.Property(x => x.NombreCategoria).IsRequired().HasMaxLength(500);

        }
    }
}
