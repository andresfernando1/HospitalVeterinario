using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Software2.Models;

namespace Software2.Controllers
{
    [Authorize]
    public class HistoriaClinicaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HistoriaClinica
        public ActionResult Index()
        {
            var historiaClinicas = db.HistoriaClinicas.Include(h => h.mascota);
            return View(historiaClinicas.ToList());
        }

        // GET: HistoriaClinica/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaClinica historiaClinica = db.HistoriaClinicas.Find(id); 
            if (historiaClinica == null)
            {
                return HttpNotFound();
            }
            return View(historiaClinica);
        }




 

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
