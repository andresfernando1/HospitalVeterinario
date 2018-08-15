using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    [NotMapped]
    public class MascotaView:Mascota
    {
        [Display(Name ="Especie")]
        public int especieId { get; set; }
    }
}