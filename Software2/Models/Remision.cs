using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Remision
    {
        [Key]
        [Display(Name = "Remision ID")]
        public int remisionID { get; set; }

        [Display(Name = "Fecha de Remision")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Ingrese la fecha")]
        public DateTime fechaRemision { get; set; }

        [Display(Name = "ID Mascota")]
        [ForeignKey("Mascota")]
        public string mascotaID { get; set; }

        public virtual Mascota Mascota { get; set; }

        [Display(Name = "ID Practicante")]
        [ForeignKey("veterinario")]
        public string veterinarioID { get; set; }

        public virtual Veterinario veterinario { get; set; }

        [Display(Name = "Region")]
        [Required(ErrorMessage = "Ingrese una region")]
        public string region { get; set; }

        [Display(Name = "Vista")]
        [Required(ErrorMessage = "Ingrese una vista")]
        public string vista { get; set; }

        [Display(Name = "Diagnostico Presuntivo")]
        [Required(ErrorMessage = "Ingrese un diagnostico")]
        public string diagnostico { get; set; }

        [Display(Name = "Ecografía")]
        [Required(ErrorMessage = "Ingrese una ecografía")]
        public string ecografia { get; set; }

        [Display(Name = "Evaluación clínica")]
        [Required(ErrorMessage = "Ingrese una evaluacion")]
        public string evaluacion { get; set; }

        [Display(Name = "Resultado")]
        [Required(ErrorMessage = "Ingrese un resultado")]
        public string resultado { get; set; }

        [Display(Name = "Observacion")]
        [Required(ErrorMessage = "Ingrese una observacion")]
        public string observacion { get; set; }



    }
}