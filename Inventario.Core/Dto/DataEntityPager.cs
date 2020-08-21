using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Dto
{
    public class DataEntityPager<T>
    {
        /// <summary>
        /// lita de resultados
        /// </summary>
        public List<T> Results { get; set; }

        /// <summary>
        /// La página mostyrada actualmente
        /// </summary>
        public int PaginaActual { get; set; }

        /// <summary>
        /// cantidad total de registros considerando todas las paginas
        /// </summary>
        public int CantidadTotal { get; set; }

        /// <summary>
        /// Cantidad de registros por pagina
        /// </summary>
        public int CantidadPorPagina { get; set; }
    }
}
