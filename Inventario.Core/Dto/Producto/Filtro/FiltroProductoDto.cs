using Inventario.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.Producto.Filtro
{
    public class FiltroProductoDto
    {
        public FiltroProductoDto(){ }
        public string Nombre { get; set; }
        public TipoProductoFiltro TipoProducto { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public Estado? Estado { get; set; }
    }
}
