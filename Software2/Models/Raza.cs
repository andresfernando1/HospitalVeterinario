using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Raza   
    {

        [Key]
        public int id { set; get; }

        [StringLength(30)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "El nombre de una raza no pueden ser números o símbolos")]
        [Required(ErrorMessage = "Ingrese un nombre para la raza")]
        public string nombre { set; get; }

        public int idEspecie { get; set; }
        [ForeignKey("idEspecie")]
        public virtual Especie especie { set; get; }

        public List<Mascota> mascotas;
    }
}