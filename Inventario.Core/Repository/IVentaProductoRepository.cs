using Inventario.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Repository
{
    public interface IVentaProductoRepository
    {
        /// <summary>
        /// Guarda o edita las VentaProducto insertadas
        /// </summary>
        /// <param name="ventaProducto"
        Task AgregarEditarCategiriasAsync(VentaProducto ventaProducto);
        /// <summary>
        /// Regresa una lista de VentaProducto paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        Task<List<VentaProducto>> GetCategoriasAsync(Expression<Func<VentaProducto, bool>> where, int itemperpage, int page);
        /// <summary>
        /// Regresa el total de resultados de la lista a paginar
        /// </summary>
        /// <param name="where"></param>
        Task<int> CountAsync(Expression<Func<VentaProducto, bool>> where);
        /// <summary>
        /// Elimina las VentaProducto
        /// </summary>
        Task EliminarCategoriaAsync(int idVenta);
        /// <summary>
        /// Extrae una VentaProducto por id
        /// </summary>
        Task<VentaProducto> GetCategoriaById(int idVenta, bool trackear = false);
        /// <summary>
        /// Guarda los cambios realizados a la base de datos
        /// </summary>
        Task SaveChangesAsync();
    }
}
