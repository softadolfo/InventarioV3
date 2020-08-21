using Inventario.Core.Model;
using Inventario.SQL.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.SQL
{
    public class InventarioContext : IdentityDbContext<Usuario>
    {
        public InventarioContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<RegistroVenta> RegistroVenta { get; set; }
        public DbSet<RegistroEntradaProducto> RegistroEntradaProducto { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<UserRol> UserRol { get; set; }
        public DbSet<VentaProducto> VentaProducto { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RolMapp());
            modelBuilder.ApplyConfiguration(new CategoriaMapp());
            modelBuilder.ApplyConfiguration(new MarcaMapp());
            modelBuilder.ApplyConfiguration(new ProductoMapp());
            modelBuilder.ApplyConfiguration(new RegistroVentaMapp());
            modelBuilder.ApplyConfiguration(new RegistroEntradaMapp());
            modelBuilder.ApplyConfiguration(new TipoProductoMapp());
            modelBuilder.ApplyConfiguration(new TipoUsuarioMapp());
            modelBuilder.ApplyConfiguration(new UserRolMapp());
            modelBuilder.ApplyConfiguration(new VentaProductoMapp());
        }
    }
}
