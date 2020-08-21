using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.SQL.Mapping
{
    public class TipoUsuarioMapp : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            //name of table
            builder.ToTable(nameof(TipoUsuario));
            //primary key
            builder.HasKey(x => x.Codigo);
            //property
            builder.Property(x => x.NombreTipoUsuario).IsRequired().HasMaxLength(200);
        }
    }
}
