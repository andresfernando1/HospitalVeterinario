using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Control
    {
        [Key]
        public string id { get; set; }

        public DateTime fecha { get; set; }

        [Display(Name = "Historia clinica")]
        [ForeignKey("historiaclinica")]
        public string historia { get; set; }

        [Required(ErrorMessage ="El campo es obligatorio")]
        [Display(Name ="Anamnesis")]
        public string anamnesis  { get; set; }

        #region examen_fisico_general
        [Display(Name ="Temperatura")]
        public double temperatura   { get; set; }

        [Display(Name ="Frecuencia cardiaca")]
        public double fc { get; set; }

        [Display(Name = "Mucosas")]
        public string mucosas { get; set; }

        [Display(Name = "Frecuencia respiratoria")]
        public double fr { get; set; }

        [Display(Name = "Tiempo de llenado capilar")]
        public double tiempo { get; set; }

        [Display(Name = "Masa corporal")]
        public double masacorporal { get; set; }
        #endregion  examen_fisico_general

        #region examen_fisico_especial

        [Display(Name ="Piel y anexos")]
        public opciones  piel  { get; set; }

        [Display(Name = "Muscolo esquelético")]
        public opciones muscolo { get; set; }

        [Display(Name = "Ojos")]
        public opciones ojos { get; set; }

        [Display(Name = "Cardiovascular")]
        public opciones cardiovascular { get; set; }

        [Display(Name = "Respiratorio")]
        public opciones respiratorio { get; set; }

        [Display(Name = "Digestivo")]
        public opciones digestivo { get; set; }

        [Display(Name = "Genito/urinario")]
        public opciones genito { get; set; }

        [Display(Name = "Reproductor")]
        public opciones reproducor { get; set; }

        [Display(Name = "Nervioso")]
        public opciones nervioso { get; set; }

        [Display(Name = "Linfatico")]
        public opciones linfatico { get; set; }


        #endregion examen_fisico_especial

        #region examen_fisico_especial_des

        [Display(Name = "Piel y anexos")]
        public string des_piel { get; set; }

        [Display(Name = "Muscolo esquelético")]
        public string des_muscolo { get; set; }

        [Display(Name = "Ojos")]
        public string des_ojos { get; set; }

        [Display(Name = "Cardiovascular")]
        public string des_cardiovascular { get; set; }

        [Display(Name = "Respiratorio")]
        public string des_respiratorio { get; set; }

        [Display(Name = "Digestivo")]
        public string des_digestivo { get; set; }

        [Display(Name = "Genito/urinario")]
        public string des_genito { get; set; }

        [Display(Name = "Reproductor")]
        public string des_reproducor { get; set; }

        [Display(Name = "Nervioso")]
        public string des_nervioso { get; set; }

        [Display(Name = "Linfatico")]
        public string des_linfatico { get; set; }


        #endregion examen_fisico_especial_des
       

        #region detalles

        [Display(Name ="Anormalidades")]
        public string anormalidades { get; set; }

        [Display(Name = "Problemas")]
        public string problemas { get; set; }

        [Display(Name = "Ayudas diagnósticas")]
        public string ayudas { get; set; }

        [Required]
        [Display(Name = "Diagnóstico final")]
        public string fianl { get; set; }
        #endregion detalles

        public enum opciones
        {
            Anormal,Normal,No_aplica
        }
        [ForeignKey("veterinario")]
        public string veterinarioFK { get; set; }
        public Veterinario veterinario { get; set; }

        public virtual HistoriaClinica historiaclinica { get; set; }
    }
}