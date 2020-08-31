using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.VentaProducto.Input
{
    public class VentaProductoInput
    {
        public int? Codigo { get; set; }
        public int IdProducto { get; set; }
        public int IdRegistroVenta { get; set; }
        public double CantidadVenta { get; set; }
    }
}
