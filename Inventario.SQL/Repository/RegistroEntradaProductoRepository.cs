using Inventario.Core.Model;
using Inventario.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Inventario.SQL.Repository
{
    public class RegistroEntradaProductoRepository : IRegistroEntradaProductoRepository
    {
        private readonly InventarioContext _db;

        public RegistroEntradaProductoRepository(InventarioContext context)
        {
            _db = context;
        }
        public async Task AgregarEditarRegistroEntradaProductoAsync(RegistroEntradaProducto registroEntradaProducto)
        {
            await _db.RegistroEntradaProducto.AddAsync(registroEntradaProducto);
        }

        public async Task<int> CountAsync(Expression<Func<RegistroEntradaProducto, bool>> where)
        {
            return await _db.RegistroEntradaProducto.CountAsync(where);
        }

        public async Task EliminarRegistroEntradaProductoAsync(int idRegistro)
        {
            RegistroEntradaProducto registroEntrada = new RegistroEntradaProducto() { Codigo = idRegistro };
            _db.Entry(registroEntrada).State = EntityState.Deleted;
        }

        public async Task<List<RegistroEntradaProducto>> GetRegistroEntradaProductoAsync(Expression<Func<RegistroEntradaProducto, bool>> where, int itemperpage, int page)
        {
            IQueryable<RegistroEntradaProducto> query;
            query = _db.RegistroEntradaProducto.Where(where)
                             .OrderBy(x => x.FechaIngreso)
                             .Skip((page - 1) * itemperpage)
                             .Take(itemperpage);
            List<RegistroEntradaProducto> productos = await query.ToListAsync().ConfigureAwait(false);
            return productos;
        }

        public async Task<RegistroEntradaProducto> GetRegistroEntradaProductoById(int idRegistro, bool trackear = false)
        {
            RegistroEntradaProducto registroEntrada;
            Expression<Func<RegistroEntradaProducto, bool>> where =
               x => x.Codigo == idRegistro;

            if (trackear)
            {
                registroEntrada = await _db.RegistroEntradaProducto.FirstOrDefaultAsync(where);
            }
            else
            {
                _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                registroEntrada = await _db.RegistroEntradaProducto.FirstOrDefaultAsync(where).ConfigureAwait(false);
            }

            return registroEntrada;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
