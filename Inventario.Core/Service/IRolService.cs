using Inventario.Core.Dto.Rol.Input;
using Inventario.Core.Dto.Rol.Output;
using Inventario.Core.Dto.Rol.Filtro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inventario.Core.Dto;

namespace Inventario.Core.Service
{
    public interface IRolService
    {
        /// <summary>
        /// Guarda o edita los roles insertadas
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarRolAsync(RolInput rol);
        /// <summary>
        /// Regresa una lista de roles paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param7
        Task<DataEntityPager<RolOutput>> GetRolAsync(FiltroRolDto filtro, int itemperpage, int page);
        /// <summary>
        /// Elimina las categorias
        /// </summary>
        Task EliminarRolAsync(int idRol);
        /// <summary>
        /// Extrae una categoria por id
        /// </summary>
        Task<RolOutput> GetRolById(int idRol);
    }
}
