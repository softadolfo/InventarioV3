using Inventario.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Repository
{
    public interface IProductoRepository
    {
        /// <summary>
        /// Guarda o edita las categorias insertadas
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarProductoAsync(Producto producto);
        /// <summary>
        /// Regresa una lista de categorias paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        Task<List<Producto>> GetProductosAsync(Expression<Func<Producto, bool>> where, int itemperpage, int page);
        /// <summary>
        /// Regresa una lista de categorias paginada
        /// </summary>
        /// <param name="idMarca"></param>
        Task<List<Producto>> GetProductoMarcaAsync(int idMarca);
        /// <summary>
        /// Regresa el total de resultados de la lista a paginar
        /// </summary>
        /// <param name="where"></param>
        Task<int> CountAsync(Expression<Func<Producto, bool>> where);
        /// <summary>
        /// Elimina las categorias
        /// </summary>
        Task EliminarProductoAsync(int idProducto);
        /// <summary>
        /// Extrae una categoria por id
        /// </summary>
        Task<Producto> GetProducotById(int idProducto, bool trackear = false);
        /// <summary>
        /// Guarda los cambios realizados a la base de datos
        /// </summary>
        Task SaveChangesAsync();
    }
}
