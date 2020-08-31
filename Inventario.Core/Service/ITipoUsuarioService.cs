using Inventario.Core.Dto;
using Inventario.Core.Dto.TipoUsuario.Filtro;
using Inventario.Core.Dto.TipoUsuario.Input;
using Inventario.Core.Dto.TipoUsuario.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Service
{
    public interface ITipoUsuarioService
    {
        /// <summary>
        /// Guarda o edita los roles insertadas
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarTipoUsuarioAsync(TipoUsuarioInput tipoUsuario);
        /// <summary>
        /// Regresa una lista de roles paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param7
        Task<DataEntityPager<TipoUsuarioOutput>> GetATipoUsuariosync(FiltroTipoUsuarioDto filtro, int itemperpage, int page);
        /// <summary>
        /// Elimina las categorias
        /// </summary>
        Task EliminarTipoUsuarioAsync(int iTipoUsuario);
        /// <summary>
        /// Extrae una categoria por id
        /// </summary>
        Task<TipoUsuarioOutput> GetTipoUsuarioById(int idUsuario);
    }
}
