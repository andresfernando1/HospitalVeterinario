using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Monitoreo
    {

        [Key]
        public int id { get; set; }

       
        [Display(Name = "Fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha { get; set; }


        [ForeignKey("historia_clinica")]
        public string historia { get; set; }


        [Display(Name ="Peso")]

        public double peso { get; set; }


        public virtual HistoriaClinica historia_clinica { get; set; }
        
        public virtual List<MonitoreoPacientes> monitoreopacientes { get; set; }
        public virtual List<PlanTerapeutico> planterapeutico { get; set; }
    }
}