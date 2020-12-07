using Inventario.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Repository
{
    public interface IUserRolRepository
    {
        /// <summary>
        /// Guarda o edita los UserRol
        /// </summary>
        /// <param name="userRol"
        Task AgregarEditarRolAsync(UserRol userRol);
        /// <summary>
        /// Regresa una lista de UserRol paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        Task<List<UserRol>> GetRolAsync(Expression<Func<UserRol, bool>> where, int itemperpage, int page);
        /// <summary>
        /// Regresa el total de resultados de la lista a paginar
        /// </summary>
        /// <param name="where"></param>
        Task<int> CountAsync(Expression<Func<UserRol, bool>> where);
        /// <summary>
        /// Elimina las UserRol
        /// </summary>
        Task EliminarRolAsync(int idUserRol);
        /// <summary>
        /// Extrae un UserRol por id
        /// </summary>
        Task<UserRol> GetRolById(int idUserRol, bool trackear = false);
        /// <summary>
        /// Guarda los cambios realizados a la base de datos
        /// </summary>
        Task SaveChangesAsync();
    }
}
