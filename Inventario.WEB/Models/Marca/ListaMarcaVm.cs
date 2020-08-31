using Inventario.Core.Dto.Marca.Filtro;
using Inventario.Core.Dto.Marca.Output;
using Inventario.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.WEB.Models.Marca
{
    public class ListaMarcaVm
    {
        public string Nombre { get; set; }

        public Estado? Estado { get; set; }
        /// <summary>
        /// Pagina actual
        /// </summary>
        public int Page { get; set; } = 1;
        public List<MarcaOutput> Marcas { get; set; }

        /// <summary>
        /// Datos de paginación
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
    }
}
