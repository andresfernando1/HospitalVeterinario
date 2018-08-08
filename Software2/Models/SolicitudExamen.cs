using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class SolicitudExamen
    {
        [Key]
        public int id { set; get; }

        [DisplayName("Numero de recibo"), Required(ErrorMessage = "Debe ingresar un número de recibo")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Debe ingresar un número")]
        public int numeroRecibo { set; get; }

        [Display(Name = "Mascota")]
        [ForeignKey("mascotaFK")]
        public string mascota { get; set; }
        public Mascota mascotaFK { get; set; }


        [DisplayName("Fecha "), Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha { get { return DateTime.Today; } }

        [DisplayName("Muestra remitida"), Required(ErrorMessage = "Debe ingresar una muestra remitida")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Debe ingresar letras en el campo muestra")]
        public string muestraRemitida { get; set; }

        [DisplayName("Examen Solicitado"), Required(ErrorMessage = "Debe ingresar un examen para solicitar")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Debe ingresar letras en el campo Examen solicitado")]
        public string examenSolicitado { get; set; }


        [DisplayName("Diagnostico Presuntivo"), Required(ErrorMessage = "Debe ingresar valores para Diagnostico presuntivo")]

        public string diagnosticoPresuntivo { set; get; }

        [DisplayName("Veterinario a cargo"), Required(ErrorMessage = "Debe ingresar un examen para solicitar")]
        [ForeignKey("veterinario")]
        public string veterinarioFK { set; get; }
        public Veterinario veterinario { set; get; }
    }
}
