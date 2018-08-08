using Software2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace Software2.Controllers
{
    public class ReportesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult MascotasAtendidas()
        {

            List<Veterinario> veterinarios = db.Veterinarios.Include(xx => xx.controles).ToList();
            return View(veterinarios);
        }
        [HttpPost]
        
        public JsonResult MascotasAtendidas(modelo model)
        {

           // List<Veterinario> veterinarios = db.Veterinarios.Include(xx => xx.controles).ToList();

            string salida = "{json:'Salida'}";
            return Json(model);
        }


    }
        public  class modelo
        {
            public string fechaInicio { get; set; }
            public string fechaFin { get; set; }
        }
    
    }