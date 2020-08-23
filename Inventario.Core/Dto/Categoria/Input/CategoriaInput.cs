using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.Categoria.Input
{
    public class CategoriaInput
    {
        public int? IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public bool Activo { get; set; }
    }
}
