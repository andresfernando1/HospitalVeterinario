using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Auto_Necropsia:Autorizacion

    {
        [Display(Name = "Diagnostico Presuntivo")]
        [Required(ErrorMessage = "El campo diagnostico es obligatorio")]

        public string Diagnostico { get; set; }
    }
}