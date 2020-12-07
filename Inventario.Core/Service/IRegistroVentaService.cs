using Inventario.Core.Dto;
using Inventario.Core.Dto.RegistroVenta.Filtro;
using Inventario.Core.Dto.RegistroVenta.Input;
using Inventario.Core.Dto.RegistroVenta.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Service
{
    public interface IRegistroVentaService
    {
        /// <summary>
        /// Guarda o edita las RegistroVentaInput insertadas
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarRegistroVentaAsync(RegistroVentaInput registroVenta);
        /// <summary>
        /// Regresa una lista de RegistroVentaInput paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param7
        Task<DataEntityPager<RegistroVentaOutput>> GetRegistroVentaAsync(FiltroRegistroVentaDto filtro, int itemperpage, int page);
        /// <summary>
        /// Elimina las RegistroVentaInput
        /// </summary>
        Task EliminarRegistroVentaAsync(int idVenta);
        /// <summary>
        /// Extrae una RegistroVentaInput por id
        /// </summary>
        Task<RegistroVentaOutput> GetRegistroVentaById(int idVenta);
    }
}
