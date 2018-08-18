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

        [DataType(DataType.Date)]
        [Display(Name ="Fecha")]
        public DateTime fecha { get; set; }

        
        [ForeignKey("historiaFK")]
        public string historia { get; set; }

        public  HistoriaClinica historiaFK { get; set; }
        
        
    }
}