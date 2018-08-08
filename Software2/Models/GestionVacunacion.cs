using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models 
{
    public class GestionVacunacion
    {

        [Key]
        public int vacunaID { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Fecha de vacunación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaVacunacion { get; set; }

        [Display(Name = "Dosis")]
        public double dosis { get; set; }

        [Display(Name = "Lote")]
        public double lote { get; set; }

        [Display(Name = "ID Mascota")]
        [ForeignKey("Mascota")]
        public string mascotaID { get; set; }

        public virtual Mascota Mascota { get; set; }

    }
}