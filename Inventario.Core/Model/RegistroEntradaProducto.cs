using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Model
{
    public class RegistroEntradaProducto
    {
        public int Codigo { get; set; }
        public DateTimeOffset FechaIngreso { get; set; }
        public int IdProducto { get; set; }
        public int CantidadProductosIngresados { get; set; }
        public Producto Producto { get; set; }
    }
}
