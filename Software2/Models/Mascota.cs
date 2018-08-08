using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Mascota
    {
        [Key]
        public string id { get; set; }

        [Display(Name ="Nombre")]
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string nombre { get; set; }

        [Display(Name = "Fecha de nacimiento")]
       
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo Fecha de nacimiento es obligatorio")]
        public DateTime fecha_nacimiento { get; set; }

        [Display(Name = "Sexo")]
        public sexos sexo { get; set; }

        [Display(Name = "Color")]
        public colores color { get; set; }

        //[Display(Name = "Raza")]
        //[ForeignKey("razaFK")]
        //public int raza { get; set; }

        [Display(Name = "Especie")]
        [ForeignKey("especieFK")]
        public int especie { get; set; }

        [Display(Name = "Propietario")]
        [ForeignKey("propietarioFK")]
        public long propietario{ get; set; }

        public virtual Propietario propietarioFK { get; set; }

    

        //public virtual Raza razaFK { get; set; }
        public virtual Especie especieFK { get; set; }

        public enum sexos { Hembra,Macho};

        public enum colores {Blanco,Negro,Dorado}

        public virtual ICollection<GestionVacunacion> gestionVacunacion { get; set; }

        public virtual ICollection<Formula> formulas { get; set; }

        public virtual ICollection<Remision> remisiones { get; set; } 

        [Display(Name = "Edad")]
        public int edad { get {
                return DateTime.Today.AddTicks(-this.fecha_nacimiento.Ticks).Year - 1;
            } }


     
        public virtual HistoriaClinica historia { get; set;}

    }

}