using Inventario.Core.Dto.Categoria.Output;
using Inventario.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.WEB.Models.Categoria
{
    public class ListaCategoriaVm
    {
        public string Nombre { get; set; }

        public Estado? Estado { get; set; }
        /// <summary>
        /// Pagina actual
        /// </summary>
        public int Page { get; set; } = 1;
        public List<CategoriaOutput> Categorias { get; set; }

        /// <summary>
        /// Datos de paginación
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
    }
}
