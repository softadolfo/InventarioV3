using Inventario.Core.Model;
using Inventario.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;


namespace Inventario.SQL.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly InventarioContext _db;

        public ProductoRepository(InventarioContext context)
        {
            _db = context;
        }
        public async Task AgregarEditarProductoAsync(Producto producto)
        {
            await _db.Producto.AddAsync(producto);
        }

        public async Task<int> CountAsync(Expression<Func<Producto, bool>> where)
        {
            return await _db.Producto.CountAsync(where);
        }

        public async Task EliminarProductoAsync(int idProducto)
        {
            Producto producto = new Producto() { Codigo = idProducto };
            _db.Entry(producto).State = EntityState.Deleted;
        }

        public async Task<Producto> GetProducotById(int idProducto, bool trackear = false)
        {
            Producto producto;
            Expression<Func<Producto, bool>> where =
               x => x.Codigo == idProducto;

            if (trackear)
            {
                producto = await _db.Producto.FirstOrDefaultAsync(where);
            }
            else
            {
                _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                producto = await _db.Producto.FirstOrDefaultAsync(where).ConfigureAwait(false);
            }

            return producto;
        }

        public async Task<List<Producto>> GetProductosAsync(Expression<Func<Producto, bool>> where, int itemperpage, int page)
        {
            IQueryable<Producto> query;
            query = _db.Producto.Where(where)
                             .OrderBy(x => x.Disponibilidad)
                             .Skip((page - 1) * itemperpage)
                             .Take(itemperpage);
            List<Producto> productos = await query.ToListAsync().ConfigureAwait(false);
            return productos;
        }

        public async Task<List<Producto>> GetProductoMarcaAsync(int idMarca)
        {
            IQueryable<Producto> query;
            query = _db.Producto.Where(x => x.IdMarca == idMarca);
            List<Producto> productos = await query.ToListAsync().ConfigureAwait(false);
            return productos;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
