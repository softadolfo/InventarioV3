using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.RegistroVenta.Filtro
{
    public class FiltroRegistroVentaDto
    {
        public FiltroRegistroVentaDto(){}
        public DateTimeOffset Fecha { get; set; }
        public string NombreUsuario { get; set; }
    }
}
