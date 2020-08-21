using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.SQL.Mapping
{
    public class VentaProductoMapp : IEntityTypeConfiguration<VentaProducto>
    {
        public void Configure(EntityTypeBuilder<VentaProducto> builder)
        {
            //name of table
            builder.ToTable(nameof(VentaProducto));
            //primary key
            builder.HasKey(x => x.Codigo);
            //property
            builder.Property(x => x.CantidadVenta).IsRequired();
            //foreign key
            builder.HasOne(x => x.Producto).WithMany().HasForeignKey(x => x.IdProducto);
            builder.HasOne(x => x.RegistroVenta).WithMany().HasForeignKey(x => x.IdRegistroVenta);
        }
    }
}
