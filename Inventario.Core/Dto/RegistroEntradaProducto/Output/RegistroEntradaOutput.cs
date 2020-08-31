using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.RegistroEntradaProducto.Output
{
    public class RegistroEntradaOutput
    {
        public int Codigo { get; set; }
        public DateTimeOffset FechaIngreso { get; set; }
        public int IdProducto { get; set; }
        public int CantidadProductosIngresados { get; set; }
    }
}
