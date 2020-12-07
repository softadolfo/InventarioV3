using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.WEB.Models.Cuenta
{
    public class LoginVm
    {
        public string user { get; set; }
        public LoginVm()
        {
            PersistirCookie = false;
        }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [MaxLength(50, ErrorMessage = "El usuario no puede tener más de 50 caracteres")]
        [MinLength(3, ErrorMessage = "El usuario debe tener al menos 3 caracteres")]
        public string Usuario { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [MaxLength(50, ErrorMessage = "La contraseña no puede tener más de 50 caracteres")]
        [MinLength(3, ErrorMessage = "La Contraseña debe tener al menos 3 caracteres")]
        public string Contrasena { get; set; }


        /// <summary>
        /// Indica que la cookie debe mantenerse viva aunque se cierre el explorador.
        /// Al final esto causa que a la cookie se le setee una fecah de vencimiento
        /// </summary>
        public bool PersistirCookie { get; set; }

        /// <summary>
        /// Si quiere que al loguearse sea redirigido hacia otra pantalla
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
