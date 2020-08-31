using Inventario.Core.Model;
using Inventario.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Inventario.SQL.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly InventarioContext _db;

        public CategoriaRepository(InventarioContext context)
        {
            _db = context;
        }
        public async Task AgregarEditarCategiriasAsync(Categoria categoria)
        {
             await _db.Categoria.AddAsync(categoria);
        }

        public async Task<int> CountAsync(Expression<Func<Categoria, bool>> where)
        {
            return await _db.Categoria.CountAsync(where);
        }

        public async Task EliminarCategoriaAsync(int idCategoria)
        {
            Categoria categoria = new Categoria() { IdCategoria = idCategoria };
            _db.Entry(categoria).State = EntityState.Deleted;
        }

        public async Task<Categoria> GetCategoriaById(int idCategoria, bool trackear = false)
        {
            Categoria categoria;
            Expression<Func<Categoria, bool>> where =
               x => x.IdCategoria == idCategoria;

            if (trackear)
            {
                categoria = await _db.Categoria.FirstOrDefaultAsync(where);
            }
            else
            {
                _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                categoria = await _db.Categoria.FirstOrDefaultAsync(where);
            }

            return categoria;
        }

        public async Task<List<Categoria>> GetCategoriasAsync(Expression<Func<Categoria, bool>> where, int itemperpage, int page)
        {
            List<Categoria> categorias = await _db.Categoria.Where(where)
                                                            .Skip((page - 1) * itemperpage)
                                                            .Take(itemperpage)
                                                            .ToListAsync();
            return categorias;
        }

        public async Task SaveChangesAsync()
        {
          await _db.SaveChangesAsync();
        }
    }
}
