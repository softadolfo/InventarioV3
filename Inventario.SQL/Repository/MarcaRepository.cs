using Inventario.Core.Model;
using Inventario.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Inventario.SQL.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly InventarioContext _db;

        public MarcaRepository(InventarioContext context)
        {
            _db = context;
        }
        public async Task AgregarEditarMarcaAsync(Marca marca)
        {
            await _db.Marca.AddAsync(marca);
        }

        public async Task<int> CountAsync(Expression<Func<Marca, bool>> where)
        {
            return await _db.Marca.CountAsync(where);
        }

        public async Task EliminarMarcaAsync(int idCategoria)
        {
            Marca marca = new Marca() { Codigo = idCategoria };
            _db.Entry(marca).State = EntityState.Deleted;
        }

        public async Task<List<Marca>> GetMarcaAsync(Expression<Func<Marca, bool>> where, int itemperpage, int page)
        {
            IQueryable<Marca> query;
            query = _db.Marca.Where(where)
                             .OrderBy(x => x.NombreMarca)
                             .Skip((page - 1) * itemperpage)
                             .Take(itemperpage);
            List<Marca> marcas = await query.ToListAsync().ConfigureAwait(false);
            return marcas;
        }

        public async Task<Marca> GetMarcaById(int idMarca, bool trackear = false)
        {
            Marca marca;
            Expression<Func<Marca, bool>> where =
               x => x.Codigo == idMarca;

            if (trackear)
            {
                marca = await _db.Marca.FirstOrDefaultAsync(where);
            }
            else
            {
                _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                marca = await _db.Marca.FirstOrDefaultAsync(where).ConfigureAwait(false);
            }

            return marca;
        }

        public async Task SaveChangesAsync()
        {
           await _db.SaveChangesAsync();
        }
    }
}
