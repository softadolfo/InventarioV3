using Inventario.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Repository
{
    public interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Guarda o edita las tipo usuario insertadas
        /// </summary>
        /// <param name="tipoUsuario"
        Task AgregarEditarTipoUsuariosAsync(TipoUsuario tipoUsuario);
        /// <summary>
        /// Regresa una lista de categorias paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        Task<List<TipoUsuario>> GetTipoUsuarioAsync(Expression<Func<TipoUsuario, bool>> where, int itemperpage, int page);
        /// <summary>
        /// Regresa el total de resultados de la lista a paginar
        /// </summary>
        /// <param name="where"></param>
        Task<int> CountAsync(Expression<Func<TipoUsuario, bool>> where);
        /// <summary>
        /// Elimina las categorias
        /// </summary>
        Task EliminarTipoUsuarioAsync(int idTipoUsuario);
        /// <summary>
        /// Extrae una categoria por id
        /// </summary>
        Task<TipoUsuario> GetTipoUsuarioById(int idTipoUsuario, bool trackear = false);
        /// <summary>
        /// Guarda los cambios realizados a la base de datos
        /// </summary>
        Task SaveChangesAsync();
    }
}
