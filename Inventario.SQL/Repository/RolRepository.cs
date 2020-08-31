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
    public class RolRepository : IRolRepository
    {
        private readonly InventarioContext _db;

        public RolRepository(InventarioContext context)
        {
            _db = context;
        }
        public async Task AgregarEditarRolAsync(Rol rol)
        {
            await _db.Rol.AddAsync(rol);
        }

        public async Task<int> CountAsync(Expression<Func<Rol, bool>> where)
        {
            return await _db.Rol.CountAsync(where);
        }

        public async Task EliminarRolAsync(int idRol)
        {
            Rol rol = new Rol() { Codigo = idRol };
            _db.Entry(rol).State = EntityState.Deleted;
        }

        public async Task<List<Rol>> GetRolAsync(Expression<Func<Rol, bool>> where, int itemperpage, int page)
        {
            List<Rol> rols = await _db.Rol.Where(where)
                                            .Skip((page - 1) * itemperpage)
                                            .Take(itemperpage)
                                            .ToListAsync();
            return rols;
        }

        public async Task<Rol> GetRolById(int idRol, bool trackear = false)
        {
            Rol rol;
            Expression<Func<Rol, bool>> where =
               x => x.Codigo == idRol;
            if (trackear)
            {
                rol = await _db.Rol.FirstOrDefaultAsync(where);
            }
            else
            {
                _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                rol = await _db.Rol.FirstOrDefaultAsync(where);
            }

            return rol;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
