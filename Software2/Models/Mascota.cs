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

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string nombre { get; set; }

        [Display(Name = "Fecha de nacimiento")]

        string fecha = "01/02/1999";

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

        [Display(Name = "Raza")]
        [ForeignKey("raza")]
        public int razaFK { get; set; }

        [Display(Name = "Propietario")]
        [ForeignKey("propietarioFK")]
        public long propietario{ get; set; }

        public virtual Propietario propietarioFK { get; set; }

        public virtual Raza raza { get; set; }

        public enum sexos { Hembra,Macho};

        public enum colores {Blanco,Negro,Dorado}

       

        [Display(Name = "Edad")]
        public String edad { get {
                int anos= DateTime.Today.AddTicks(-this.fecha_nacimiento.Ticks).Year - 1;
                if (anos < 1)
                {
                    DateTime nacimiento = this.fecha_nacimiento;
                    DateTime hoy = DateTime.Now;
                    return (hoy.Month - nacimiento.Month).ToString() + " Meses";
                        }
                return anos.ToString()+" Años";
            } }


     
        public virtual HistoriaClinica historia { get; set;}

    }

}