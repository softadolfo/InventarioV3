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
    public class UserRolRepository : IUserRolRepository
    {
        private readonly InventarioContext _db;

        public UserRolRepository(InventarioContext context)
        {
            _db = context;
        }
        public async Task AgregarEditarRolAsync(UserRol userRol)
        {
            await _db.UserRol.AddAsync(userRol);
        }

        public async Task<int> CountAsync(Expression<Func<UserRol, bool>> where)
        {
            return await _db.UserRol.CountAsync(where);
        }

        public async Task EliminarRolAsync(int idUserRol)
        {
            UserRol rol = new UserRol() { IdRol = idUserRol };
            _db.Entry(rol).State = EntityState.Deleted;
        }

        public async Task<List<UserRol>> GetRolAsync(Expression<Func<UserRol, bool>> where, int itemperpage, int page)
        {
            IQueryable<UserRol> query;
            query = _db.UserRol.Where(where)
                             .Skip((page - 1) * itemperpage)
                             .Take(itemperpage);
            List<UserRol> userRol = await query.ToListAsync().ConfigureAwait(false);
            return userRol;
        }

        public async Task<UserRol> GetRolById(int idUserRol, bool trackear = false)
        {
            UserRol userRol;
            Expression<Func<UserRol, bool>> where =
               x => x.IdRol == idUserRol;

            if (trackear)
            {
                userRol = await _db.UserRol.FirstOrDefaultAsync(where);
            }
            else
            {
                _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                userRol = await _db.UserRol.FirstOrDefaultAsync(where).ConfigureAwait(false);
            }

            return userRol;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
