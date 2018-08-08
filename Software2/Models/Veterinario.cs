using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Veterinario
    {
        [Key]
        //[Required(ErrorMessage = "El ID es obligatorio")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID")]
        public string ID { get; set; }

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

        public string nombreCompleto
        {
            get
            {
                return nombre + " " + apellido;
            }
        }

        public string role { get; set; }

        public List<Control> controles { get; set; }

        public int mascotasAtendidas {
            get {
                int total = -1;
                if (controles != null)
                    total= controles.Count;

                return total;
                    } }
    }

}
