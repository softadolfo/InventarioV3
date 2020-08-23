using Inventario.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Repository
{
    public interface IMarcaRepository
    {
        /// <summary>
        /// Guarda o edita las marca insertadas
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarMarcaAsync(Marca marca);
        /// <summary>
        /// Regresa una lista de marcas paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        Task<List<Marca>> GetMarcaAsync(Expression<Func<Marca, bool>> where, int itemperpage, int page);
        /// <summary>
        /// Regresa el total de resultados de la lista a paginar
        /// </summary>
        /// <param name="where"></param>
        Task<int> CountAsync(Expression<Func<Marca, bool>> where);
        /// <summary>
        /// Elimina las categorias
        /// </summary>
        Task EliminarMarcaAsync(int idCategoria);
        /// <summary>
        /// Extrae una categoria por id
        /// </summary>
        Task<Marca> GetMarcaById(int idMarca, bool trackear = false);
        /// <summary>
        /// Guarda los cambios realizados a la base de datos
        /// </summary>
        Task SaveChangesAsync();
    }
}
