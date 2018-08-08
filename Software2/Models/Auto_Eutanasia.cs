using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Auto_Eutanasia:Autorizacion
    {

        [Display(Name = "Causa de sacrificio:")]
        [Required(ErrorMessage = "El campo causa de sacrificio es obligatorio")]

        public string causa { get; set; }

        [Display(Name = "Sección:")]
        [Required(ErrorMessage = "El campo sección es obligatorio")]

        public string seccion { get; set; }





    }
}