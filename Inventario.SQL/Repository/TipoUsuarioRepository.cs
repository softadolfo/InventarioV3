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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly InventarioContext _db;

        public TipoUsuarioRepository(InventarioContext context)
        {
            _db = context;
        }
        public async Task AgregarEditarTipoUsuariosAsync(TipoUsuario tipoUsuario)
        {
            await _db.TipoUsuario.AddAsync(tipoUsuario);
        }

        public async Task<int> CountAsync(Expression<Func<TipoUsuario, bool>> where)
        {
            return await _db.TipoUsuario.CountAsync(where);
        }

        public async Task EliminarTipoUsuarioAsync(int idTipoUsuario)
        {
            TipoUsuario tipoUsuario = new TipoUsuario() { Codigo = idTipoUsuario };
            _db.Entry(tipoUsuario).State = EntityState.Deleted;
        }

        public async Task<List<TipoUsuario>> GetTipoUsuarioAsync(Expression<Func<TipoUsuario, bool>> where, int itemperpage, int page)
        {
            IQueryable<TipoUsuario> query;
            query = _db.TipoUsuario.Where(where)
                             .OrderBy(x => x.NombreTipoUsuario)
                             .Skip((page - 1) * itemperpage)
                             .Take(itemperpage);
            List<TipoUsuario> tipoUsuarios = await query.ToListAsync().ConfigureAwait(false);
            return tipoUsuarios;
        }

        public async Task<TipoUsuario> GetTipoUsuarioById(int idTipoUsuario, bool trackear = false)
        {
            TipoUsuario tipoUsuario;
            Expression<Func<TipoUsuario, bool>> where =
               x => x.Codigo == idTipoUsuario;

            if (trackear)
            {
                tipoUsuario = await _db.TipoUsuario.FirstOrDefaultAsync(where);
            }
            else
            {
                _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                tipoUsuario = await _db.TipoUsuario.FirstOrDefaultAsync(where);
            }

            return tipoUsuario;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
