using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Model
{
    public class UserRol
    {
        public int IdRol { get; set; }
        public int IdUsuario { get; set; }
        public Rol Rol { get; set; }
        public Usuario Usuario { get; set; }
    }
}
