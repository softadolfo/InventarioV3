using Inventario.Core.Dto;
using Inventario.Core.Dto.Marca.Filtro;
using Inventario.Core.Dto.Marca.Input;
using Inventario.Core.Dto.Marca.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Service
{
    public interface IMarcaService
    {
        /// <summary>
        /// Guarda o edita las categorias insertadas
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarMarcaAsync(MarcaInput marca);
        /// <summary>
        /// Regresa una lista de categorias paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param7
        Task<DataEntityPager<MarcaOutput>> GetMarcasAsync(FiltroMarcaDto filtro, int itemperpage, int page);
        /// <summary>
        /// Elimina las categorias
        /// </summary>
        Task EliminarMarcaAsync(int idMarca);
        /// <summary>
        /// Extrae una categoria por id
        /// </summary>
        Task<MarcaOutput> GetMarcaById(int idMarca);
        /// <summary>
        /// Desactiva o Activa una Seccion.
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="activar"></param>
        /// <returns></returns>
        Task DesactivarActivarMarcaAsync(int codigo, bool activar);
    }
}
