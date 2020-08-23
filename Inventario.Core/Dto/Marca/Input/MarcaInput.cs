using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.Marca.Input
{
    public class MarcaInput
    {
        public int? Codigo { get; set; }
        public string NombreMarca { get; set; }
        public bool Activo { get; set; }
    }
}
