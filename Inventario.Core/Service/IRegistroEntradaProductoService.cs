using Inventario.Core.Dto;
using Inventario.Core.Dto.RegistroEntradaProducto.Filtro;
using Inventario.Core.Dto.RegistroEntradaProducto.Input;
using Inventario.Core.Dto.RegistroEntradaProducto.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Service
{
    public interface IRegistroEntradaProductoService
    {
        /// <summary>
        /// Guarda o edita las RegistroEntradaProducto insertadas
        /// </summary>
        /// <param name="registroEntrada"
        Task AgregarEditarRegistroEntradaProductoAsync(RegistroEntradaInput registroEntrada);
        /// <summary>
        /// Regresa una lista de RegistroEntradaProducto paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        Task<DataEntityPager<RegistroEntradaOutput>> GetRegistroEntradaProductosAsync(FiltroEntradaProdDto filtro, int itemperpage, int page);
        /// <summary>
        /// Elimina las RegistroEntradaProducto
        /// </summary>
        Task EliminarRegistroEntradaProductoAsync(int idRegistro);
        /// <summary>
        /// Extrae una RegistroEntradaProducto por id
        /// </summary>
        Task<RegistroEntradaOutput> GetRegistroEntradaProductoById(int idRegistro);
    }
}
