using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.WEB.Models.Marca
{
    public class MarcaVm
    {
        public MarcaVm()
        {
            this.Activo = true;
        }
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "El nombre de la marca es requerido")]
        public string NombreMarca { get; set; }
        public bool Activo { get; set; }
    }
}
