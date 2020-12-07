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
    public class RegistroVentaRepository : IRegistroVentaRepository
    {
        private readonly InventarioContext _db;

        public RegistroVentaRepository(InventarioContext context)
        {
            _db = context;
        }
        public async Task AgregarEditarRegistroVentaAsync(RegistroVenta registroVenta)
        {
            await _db.RegistroVenta.AddAsync(registroVenta);
        }

        public async Task<int> CountAsync(Expression<Func<RegistroVenta, bool>> where)
        {
            return await _db.RegistroVenta.CountAsync(where);
        }

        public async Task EliminarRegistroVentaAsync(int idVenta)
        {
            RegistroVenta registroVenta = new RegistroVenta() { Codigo = idVenta };
            _db.Entry(registroVenta).State = EntityState.Deleted;
        }

        public async Task<List<RegistroVenta>> GetRegistroVentaAsync(Expression<Func<RegistroVenta, bool>> where, int itemperpage, int page)
        {
            IQueryable<RegistroVenta> query;
            query = _db.RegistroVenta.Where(where)
                             .OrderBy(x => x.FechaVenta)
                             .Skip((page - 1) * itemperpage)
                             .Take(itemperpage);
            List<RegistroVenta> registroVentas = await query.ToListAsync().ConfigureAwait(false);
            return registroVentas;
        }

        public async Task<RegistroVenta> GetRegistroVentaById(int idVenta, bool trackear = false)
        {
            RegistroVenta registroVenta;
            Expression<Func<RegistroVenta, bool>> where =
               x => x.Codigo == idVenta;

            if (trackear)
            {
                registroVenta = await _db.RegistroVenta.FirstOrDefaultAsync(where);
            }
            else
            {
                _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                registroVenta = await _db.RegistroVenta.FirstOrDefaultAsync(where).ConfigureAwait(false);
            }
            return registroVenta;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
