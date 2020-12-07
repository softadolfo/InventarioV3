using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.RegistroVenta.Output
{
    public class RegistroVentaOutput
    {
        public int Codigo { get; set; }
        public DateTimeOffset? FechaVenta { get; set; }
        public decimal TotalVenta { get; set; }
        public string IdUsuario { get; set; }
    }
}
