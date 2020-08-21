using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Model
{
    public class RegistroVenta
    {
        public int Codigo { get; set; }
        public DateTimeOffset? FechaVenta { get; set; }
        public decimal TotalVenta { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
