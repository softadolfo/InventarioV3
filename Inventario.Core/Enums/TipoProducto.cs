using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventario.Core.Enums
{
    public enum TipoProducto
    {
        [Display(Name = "Ropa variada")]
        Ropa = 1,
        [Display(Name = "Zapatos")]
        Zapatos = 2,
    }
}
