using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.SQL.Mapping
{
    public class UserRolMapp : IEntityTypeConfiguration<UserRol>
    {
        public void Configure(EntityTypeBuilder<UserRol> builder)
        {
            //name of table
            builder.ToTable(nameof(UserRol));
            //primary key
            builder.HasKey(x => new {x.IdRol, x.IdUsuario });
            //property
            builder.Property(x => x.IdUsuario).IsRequired();
            //foreign key
            builder.HasOne(x => x.Rol).WithMany().HasForeignKey(x => x.IdRol);
        }
    }
}
