using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.RegistroEntradaProducto.Input
{
    public class RegistroEntradaInput
    {
        public int? Codigo { get; set; }
        public DateTimeOffset FechaIngreso { get; set; }
        public int IdProducto { get; set; }
        public int CantidadProductosIngresados { get; set; }
    }
}
