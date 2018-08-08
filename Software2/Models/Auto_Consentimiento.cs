using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Auto_Consentimiento: Autorizacion
    {
        [Required(ErrorMessage = "El campo valor es obligatorio")]
        public double valor { get; set; }

        [Range(1,100,ErrorMessage ="Debe ser un numero entre uno y 100")]
        [Required(ErrorMessage = "El campo interes es obligatorio")]
        public double interes { get; set; }
    }
}