using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.SQL.Mapping
{
    public class RolMapp : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            //name of table
            builder.ToTable(nameof(Rol));
            //primary key
            builder.HasKey(x => x.Codigo);
            //property
            builder.Property(x => x.Descripcion).IsRequired();
            builder.Property(x => x.TipoAcceso).IsRequired();

        }
    }
}
