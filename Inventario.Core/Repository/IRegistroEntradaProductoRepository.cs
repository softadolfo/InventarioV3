using Inventario.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Repository
{
    public interface IRegistroEntradaProductoRepository
    {
        /// <summary>
        /// Guarda o edita las RegistroEntradaProducto insertadas
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarRegistroEntradaProductoAsync(RegistroEntradaProducto registroEntradaProducto);
        /// <summary>
        /// Regresa una lista de RegistroEntradaProducto paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        Task<List<RegistroEntradaProducto>> GetRegistroEntradaProductoAsync(Expression<Func<RegistroEntradaProducto, bool>> where, int itemperpage, int page);
        /// <summary>
        /// Regresa el total de resultados de la lista a paginar
        /// </summary>
        /// <param name="where"></param>
        Task<int> CountAsync(Expression<Func<RegistroEntradaProducto, bool>> where);
        /// <summary>
        /// Elimina las RegistroEntradaProducto
        /// </summary>
        Task EliminarRegistroEntradaProductoAsync(int idRegistro);
        /// <summary>
        /// Extrae una RegistroEntradaProducto por id
        /// </summary>
        Task<RegistroEntradaProducto> GetRegistroEntradaProductoById(int idRegistro, bool trackear = false);
        /// <summary>
        /// Guarda los cambios realizados a la base de datos
        /// </summary>
        Task SaveChangesAsync();
    }
}
