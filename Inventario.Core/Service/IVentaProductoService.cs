using Inventario.Core.Dto;
using Inventario.Core.Dto.VentaProducto.Input;
using Inventario.Core.Dto.VentaProducto.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Service
{
    public interface IVentaProductoService
    {
        /// <summary>
        /// Guarda o edita las VentaProducto insertadas
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarVentaProductoAsync(VentaProductoInput ventaProducto);
        /// <summary>
        /// Regresa una lista de VentaProducto paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        Task<DataEntityPager<VentaProductoOutput>> GetVentaProductoAsync(int itemperpage, int page);
        /// <summary>
        /// Elimina las VentaProducto
        /// </summary>
        Task EliminarVentaProductoAsync(int idVenta);
        /// <summary>
        /// Extrae una VentaProducto por id
        /// </summary>
        Task<VentaProductoOutput> GetVentaProductoById(int idVenta);
    }
}
