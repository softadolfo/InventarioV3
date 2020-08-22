using Inventario.Core.Dto.Categoria.Input;
using Inventario.Core.Dto.Categoria.Output;
using Inventario.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Repository
{
    public interface ICategoriaRepository
    {
        /// <summary>
        /// Guarda o edita las categorias insertadas
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarCategiriasAsync(Categoria categoria);
        /// <summary>
        /// Regresa una lista de categorias paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        Task<List<Categoria>> GetCategoriasAsync(Expression<Func<Categoria, bool>> where, int itemperpage, int page);
        /// <summary>
        /// Regresa el total de resultados de la lista a paginar
        /// </summary>
        /// <param name="where"></param>
        Task<int> CountAsync(Expression<Func<Categoria, bool>> where);
        /// <summary>
        /// Elimina las categorias
        /// </summary>
        Task EliminarCategoriaAsync(int idCategoria);
        /// <summary>
        /// Extrae una categoria por id
        /// </summary>
        Task<Categoria> GetCategoriaById(int idCategoria, bool trackear = false);
        /// <summary>
        /// Guarda los cambios realizados a la base de datos
        /// </summary>
        Task SaveChangesAsync();
    }
}
