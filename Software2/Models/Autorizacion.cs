using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Autorizacion
    {
        [Key]
        public int id { get; set; }

        public DateTime fecha { get; set; }


        [Display(Name = "# Historia Clinica")]
        [ForeignKey("historiaFK")]
        public string historia { get; set; }

        public virtual HistoriaClinica historiaFK { get; set; }


    }
}