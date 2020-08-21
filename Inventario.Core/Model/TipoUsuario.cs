using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Model
{
    public class TipoUsuario
    {
        public int Codigo { get; set; }
        public string NombreTipoUsuario { get; set; }
        public bool Activo { get; set; }
    }
}
