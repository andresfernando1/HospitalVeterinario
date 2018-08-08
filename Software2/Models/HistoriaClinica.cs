using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class HistoriaClinica
    {
        [Key,ForeignKey("mascota")]
        public string id { get; set; }

        
        [Display(Name ="Fecha de creacion")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha_creacion { get; set; }


       

        public virtual List<Control> controles { get; set; }
        public virtual Mascota mascota { get; set; }

        public virtual List<Monitoreo> monitoreo { get; set; }
    }
}