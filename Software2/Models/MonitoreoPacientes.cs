using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class MonitoreoPacientes
    {
        [Key]
        public int id { get; set; }


        [Display(Name ="Fecha y hora")]
        public DateTime fecha_hora { get; set; }

        [Display(Name ="Temperatura")]
        public double temperatura { get; set; }


        [Display(Name ="Pulso")]
        public double pulso { get; set; }

        [Display(Name ="TRC???")]
        public string trc { get; set; }

        [Display(Name ="Frecuencia cardiaca")]
        public double fr { get; set; }

        [Display(Name ="Peritaltismo")]
        public string peritaltismo { get; set; }

        [Display(Name ="Mucosas")]
        public String mucosas { get; set; }

        [Display(Name ="Observación")]
        public string observacion { get; set; }

        [ForeignKey("monitoreo")]
        public int monitoreoFk { get; set; }

        public virtual Monitoreo monitoreo { get; set; }
    }
}