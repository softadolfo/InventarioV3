using Inventario.Core.Dto;
using Inventario.Core.Dto.UserRol.Input;
using Inventario.Core.Dto.UserRol.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Service
{
    public interface IUserRolService
    {
        /// <summary>
        /// Guarda o edita los UserRol insertadas
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarUserRolAsync(UserRolInput rol);
        /// <summary>
        /// Regresa una lista de UserRol paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param7
        Task<DataEntityPager<UserRolOutput>> GetUserRolAsync(int itemperpage, int page);
        /// <summary>
        /// Elimina las UserRol
        /// </summary>
        Task EliminarRolAsync(int idRol);
        /// <summary>
        /// Extrae una UserRol por id
        /// </summary>
        Task<UserRolOutput> GetUserRolById(int idRol);
    }
}
