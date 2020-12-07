using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.RegistroEntradaProducto.Filtro
{
    public class FiltroEntradaProdDto
    {
        public FiltroEntradaProdDto(){}
        public DateTimeOffset Fecha { get; set; }
        public string NombreProducto { get; set; }
    }
}
