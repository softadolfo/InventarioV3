using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Model;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Inventario.Core.Model
{
    public class Rol
    {
        public int Codigo { get; set; }
        public string TipoAcceso { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
