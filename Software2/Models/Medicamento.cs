using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Medicamento
    {
        [Display(Name = "ID Medicamento")]
        public int medicamentoID { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Dosis")]
        public int dosis { get; set; }

        [Display(Name = "Lotes")]
        public int lote { get; set; }

        [Display(Name = "Vía de Suministro")]
        public ViaSuministro viaSuministro { get; set; }

        [Display(Name = "Frecuencia")]
        public string frecuencia { get; set; }
                       
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }
    }
}