using Inventario.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto.Categoria.Filtro
{
    public class FiltroCategoriaDto
    {
        public FiltroCategoriaDto() { }

        //nombre de la categoria a filtrar
        public string Nombre { get; set; }

        public Estado? Estado { get; set; }
    }
}
