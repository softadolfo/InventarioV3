using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.SQL.Mapping
{
    public class ProductoMapp : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            //name of table
            builder.ToTable(nameof(Producto));
            //primary key
            builder.HasKey(x => x.Codigo);
            //property
            builder.Property(x => x.NombreProducto).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DescripcionProducto).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PrecioVenta).IsRequired();
            //foreign key
            builder.HasOne(x => x.Marca).WithMany().HasForeignKey(x => x.IdMarca);
            builder.HasOne(x => x.Categoria).WithMany().HasForeignKey(x => x.IdCategoria);
        }
    }
}
