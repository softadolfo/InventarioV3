using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.WEB.Models.Categoria
{
    public class CategoriaVm
    {
        public CategoriaVm()
        {
            this.Activo = true;
        }
        public int? IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre de la categoria es requerido")]
        public string NombreCategoria { get; set; }
        public bool Activo { get; set; }
    }
}
