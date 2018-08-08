using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Auto_Cirugia:Autorizacion
    {
        [Display(Name = "Observaciones")]
        [Required(ErrorMessage = "El campo observaciones es obligatorio")]
        public String observaciones { get; set; }

    }
}