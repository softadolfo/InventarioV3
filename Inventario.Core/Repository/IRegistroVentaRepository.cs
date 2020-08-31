using Inventario.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Repository
{
    public interface IRegistroVentaRepository
    {
        /// <summary>
        /// Guarda o edita las RegistroVenta insertadas
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarRegistroVentaAsync(RegistroVenta registroVenta);
        /// <summary>
        /// Regresa una lista de RegistroVenta paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        Task<List<RegistroVenta>> GetCategoriasAsync(Expression<Func<RegistroVenta, bool>> where, int itemperpage, int page);
        /// <summary>
        /// Regresa el total de resultados de la lista a paginar
        /// </summary>
        /// <param name="where"></param>
        Task<int> CountAsync(Expression<Func<RegistroVenta, bool>> where);
        /// <summary>
        /// Elimina las RegistroVenta
        /// </summary>
        Task EliminarCategoriaAsync(int idVenta);
        /// <summary>
        /// Extrae una RegistroVenta por id
        /// </summary>
        Task<RegistroVenta> GetCategoriaById(int idVenta, bool trackear = false);
        /// <summary>
        /// Guarda los cambios realizados a la base de datos
        /// </summary>
        Task SaveChangesAsync();
    }
}
