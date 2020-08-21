using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.SQL.Mapping
{
    public class RegistroVentaMapp : IEntityTypeConfiguration<RegistroVenta>
    {
        public void Configure(EntityTypeBuilder<RegistroVenta> builder)
        {
            //name of table
            builder.ToTable(nameof(RegistroVenta));
            //primary key
            builder.HasKey(x => x.Codigo);
            //property
            builder.Property(x => x.TotalVenta).IsRequired();
            builder.Property(x => x.IdUsuario).IsRequired();
        }
    }
}
