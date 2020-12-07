using Inventario.Core.Model;
using Inventario.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Text;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inventario.SQL.Repository
{
    public class VentaProductoRepository : IVentaProductoRepository
    {
        private readonly InventarioContext _db;

        public VentaProductoRepository(InventarioContext context)
        {
            _db = context;
        }
        public async Task AgregarEditarCategiriasAsync(VentaProducto ventaProducto)
        {
            await _db.VentaProducto.AddAsync(ventaProducto);
        }

        public async Task<int> CountAsync(Expression<Func<VentaProducto, bool>> where)
        {
            return await _db.VentaProducto.CountAsync(where);
        }

        public async Task EliminarCategoriaAsync(int idVenta)
        {
            VentaProducto venta = new VentaProducto() { Codigo = idVenta };
            _db.Entry(venta).State = EntityState.Deleted;
        }

        public async Task<VentaProducto> GetCategoriaById(int idVenta, bool trackear = false)
        {
            VentaProducto ventaProducto;
            Expression<Func<VentaProducto, bool>> where =
               x => x.Codigo == idVenta;

            if (trackear)
            {
                ventaProducto = await _db.VentaProducto.FirstOrDefaultAsync(where);
            }
            else
            {
                _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                ventaProducto = await _db.VentaProducto.FirstOrDefaultAsync(where).ConfigureAwait(false);
            }

            return ventaProducto;
        }

        public async Task<List<VentaProducto>> GetCategoriasAsync(Expression<Func<VentaProducto, bool>> where, int itemperpage, int page)
        {
            IQueryable<VentaProducto> query;
            query = _db.VentaProducto.Where(where)
                             .OrderBy(x => x.CantidadVenta)
                             .Skip((page - 1) * itemperpage)
                             .Take(itemperpage);
            List<VentaProducto> ventaProductos = await query.ToListAsync().ConfigureAwait(false);
            return ventaProductos;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
