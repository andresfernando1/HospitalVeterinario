﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models //Carlos Mario Jaramillo
{
    public class Propietario
    {
        [Key]
        [Display(Name ="Cédula")]
        [DataType(DataType.Text)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long cedula { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string nombre { get; set; }

        

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string apellido { get; set; }

        [Display(Name = "Nombre")]

        public string nombreCompleto
        {
            get
            { 
                return nombre + " "+apellido;
            }
        }

        [Display(Name ="Celular")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El número de celular no puede tener letras símbolos")]
        [Required(ErrorMessage = "El campo Celular es obligatorio")]
        public string celular { get; set; }

        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        public string correo { get; set; }

        public List<Mascota> mascotas { get; set; }


        

    }
}