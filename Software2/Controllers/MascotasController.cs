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
    public class MascotasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mascotas
        public ActionResult Index()
        {
            var mascotas = db.Mascotas.Include(m => m.historia).Include(m => m.propietarioFK).Include(m => m.especieFK);
            return View(mascotas.ToList());
        }

        // GET: Mascotas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // GET: Mascotas/Create
        public ActionResult Create(string id)
        {

            ViewBag.propietario = id;
            ViewBag.especie = new SelectList(db.Especies, "id", "nombre");
            ViewBag.raza = new SelectList(db.Razas, "id", "nombre");
            return View();
        }

        // POST: Mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                mascota.propietario = Convert.ToInt64(mascota.id);
                mascota.id = Metodos.generarCodigo();
                if (mascota.fecha_nacimiento > DateTime.Now) //Esto no funciona pero hay que arreglarlo
                {
                    ModelState.AddModelError("Lafecha de nacimiento no es valida", "");
                    return RedirectToAction("Index");
                }
                var historia = new HistoriaClinica();
                historia.id = mascota.id;
                historia.fecha_creacion = DateTime.Now.Date;
                db.HistoriaClinicas.Add(historia);

                db.Mascotas.Add(mascota);
                db.SaveChanges();
                return RedirectToAction("Details","Propietarios",new { id =mascota.propietario});
            }

            ViewBag.id = new SelectList(db.HistoriaClinicas, "id", "id", mascota.id);
           // ViewBag.propietario = new SelectList(db.Propietarios, "cedula", "nombre", mascota.propietario);
            ViewBag.raza = new SelectList(db.Razas.OrderBy(t => t.nombre), "id", "nombre");
            ViewBag.especie = new SelectList(db.Especies.OrderBy(t=> t.nombre), "id", "nombre");
            return View(mascota);
        }

        // GET: Mascotas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.HistoriaClinicas, "id", "id", mascota.id);
            ViewBag.propietario = new SelectList(db.Propietarios, "cedula", "nombre", mascota.propietario);
            ViewBag.especie = new SelectList(db.Razas, "id", "nombre", mascota.especie);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,fecha_nacimiento,sexo,color,raza,propietario")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.HistoriaClinicas, "id", "id", mascota.id);
            ViewBag.propietario = new SelectList(db.Propietarios, "cedula", "nombre", mascota.propietario);
            ViewBag.raza = new SelectList(db.Razas, "id", "nombre", mascota.especie);
            return View(mascota);
        }
       
        // GET: Mascotas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mascota mascota = db.Mascotas.Find(id);
            db.Mascotas.Remove(mascota);
            db.SaveChanges();
            return RedirectToAction("Index");
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
