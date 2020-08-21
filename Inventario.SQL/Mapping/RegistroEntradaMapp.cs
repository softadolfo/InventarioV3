using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.SQL.Mapping
{
    public class RegistroEntradaMapp : IEntityTypeConfiguration<RegistroEntradaProducto>
    {
        public void Configure(EntityTypeBuilder<RegistroEntradaProducto> builder)
        {
            //name of table
            builder.ToTable(nameof(RegistroEntradaProducto));
            //primary key
            builder.HasKey(x => x.Codigo);
            //foreign key
            builder.HasOne(x => x.Producto).WithMany().HasForeignKey(x => x.IdProducto);
        }
    }
}
