using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Model
{
    public class VentaProducto
    {
        public int Codigo { get; set; }
        public int IdProducto { get; set; }
        public int IdRegistroVenta { get; set; }
        public double CantidadVenta { get; set; }
        public RegistroVenta RegistroVenta { get; set; }
        public Producto Producto { get; set; }
    }
}
