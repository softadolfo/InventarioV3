using Inventario.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Repository
{
    public interface IRolRepository
    {
        /// <summary>
        /// Guarda o edita los roles
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarRolAsync(Rol rol);
        /// <summary>
        /// Regresa una lista de roles paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        Task<List<Rol>> GetRolAsync(Expression<Func<Rol, bool>> where, int itemperpage, int page);
        /// <summary>
        /// Regresa el total de resultados de la lista a paginar
        /// </summary>
        /// <param name="where"></param>
        Task<int> CountAsync(Expression<Func<Rol, bool>> where);
        /// <summary>
        /// Elimina las roles
        /// </summary>
        Task EliminarRolAsync(int idRol);
        /// <summary>
        /// Extrae un rol por id
        /// </summary>
        Task<Rol> GetRolById(int idRol, bool trackear = false);
        /// <summary>
        /// Guarda los cambios realizados a la base de datos
        /// </summary>
        Task SaveChangesAsync();
    }
}
