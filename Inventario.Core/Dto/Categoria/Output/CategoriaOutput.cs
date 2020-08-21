using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.Categoria.Output
{
    public class CategoriaOutput
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public bool Activo { get; set; }
    }
}
