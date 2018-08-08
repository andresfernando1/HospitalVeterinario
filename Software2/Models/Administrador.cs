using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Administrador
    {
        [Key]
     
        [Display(Name = "ID")]
        public string adminID { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Ingrese un nombre")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "El nombre no pueden ser números o símbolos")]
        public string nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Ingrese un Apellido")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "El apellido no pueden ser números o símbolos")]
        public string apellido { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "Ingrese un correo")]
        [DataType(DataType.EmailAddress)]
        public string correo { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Ingrese una contraseña")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [Compare("password", ErrorMessage = "Las contraseñas no coinciden")]
        [Required(ErrorMessage = "Confirme contraseña")]
        [DataType(DataType.Password)]
        public string repetirPassword { get; set; }
    }
}