using Inventario.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.Marca.Filtro
{
    public class FiltroMarcaDto
    {
        public FiltroMarcaDto() { }

        //Nombre de la marca a filtrar
        public string Nombre { get; set; }
        public Estado? Estado { get; set; }
    }
}
