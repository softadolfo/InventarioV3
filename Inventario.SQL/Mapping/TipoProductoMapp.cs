using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.SQL.Mapping
{
    public class TipoProductoMapp : IEntityTypeConfiguration<TipoProducto>
    {
        public void Configure(EntityTypeBuilder<TipoProducto> builder)
        {
            //name of table
            builder.ToTable(nameof(TipoProducto));
            //primary key
            builder.HasKey(x => x.Codigo);
            //property
            builder.Property(x => x.NombreTipoProducto).IsRequired().HasMaxLength(200);
        }
    }
}
