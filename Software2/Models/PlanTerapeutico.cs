using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class PlanTerapeutico
    {
        [Key]
        public int id { get; set; }

        [Display(Name ="Fecha y hora")]
        public DateTime fecha_hora { get; set; }

        [Display(Name = "Tipo")]
        public tipos tipo { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }


        [Display(Name = "Observación")]
        public string observacion { get; set; }



        public enum tipos { Fármaco,Fluidos,Procedimientos}


        [ForeignKey("monitoreo")]
        public int monitoreoFk { get; set; }

        public virtual Monitoreo monitoreo { get; set; }
    }
}