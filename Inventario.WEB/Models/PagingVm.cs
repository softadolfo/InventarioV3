using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.WEB.Models
{
    public class PagingVm
    {
        public string UrlPaginaAnterior { get; set; }

        public List<BotonPaginacionVm> Botones { get; set; }

        public string UrlPaginaSiguiente { get; set; }

        public int PaginaActiva { get; set; }
    }
    public class BotonPaginacionVm
    {
        public string UrlBoton { get; set; }

        public int Pagina { get; set; }
    }
}
