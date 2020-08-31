using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.Rol.Input
{
    public class RolInput
    {
        public int? Codigo { get; set; }
        public string TipoAcceso { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
