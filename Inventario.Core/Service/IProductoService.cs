using Inventario.Core.Dto;
using Inventario.Core.Dto.Producto.Filtro;
using Inventario.Core.Dto.Producto.Input;
using Inventario.Core.Dto.Producto.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Core.Service
{
    public interface IProductoService
    {
        /// <summary>
        /// Guarda o edita las producto insertadas
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarProductoAsync(ProductoInput producto);
        /// <summary>
        /// Regresa una lista de producto paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="filtro"></param7
        Task<DataEntityPager<ProductoInput>> GetProductosAsync(FiltroProductoDto filtro, int itemperpage, int page);
        /// <summary>
        /// Elimina las producto
        /// </summary>
        Task EliminarProductoAsync(int idProducto);
        /// <summary>
        /// Extrae un producto por id
        /// </summary>
        Task<ProductoOutput> GetProductoById(int idProducto);
        /// <summary>
        /// Extrae una lista producto por id
        /// </summary>
        Task<List<ProductoOutput>> GetProductosMarcaAsync(int idMarca);
    }
}
