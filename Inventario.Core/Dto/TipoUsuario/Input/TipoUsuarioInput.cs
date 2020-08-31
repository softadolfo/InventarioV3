using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.TipoUsuario.Input
{
    public class TipoUsuarioInput
    {
        public int? Codigo { get; set; }
        public string NombreTipoUsuario { get; set; }
        public bool Activo { get; set; }
    }
}
