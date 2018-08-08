using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Especie
    {

        public int id { get; set; }
        [StringLength(30)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "El nombre de una especie no pueden ser números o símbolos")]
        [Required(ErrorMessage = "Ingrese un nombre para la especie")]
        public String nombre { get; set; }

        public virtual List<Raza> razas { get; set; }

        public List<Mascota> mascotas;
       
    }  
}