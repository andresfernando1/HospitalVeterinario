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
    public class GestionVacunacionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GestionVacunacions
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Mascota mascota = db.Mascotas.Find(id);
            ViewBag.mascota = mascota;

            if (mascota == null)
            {
                return HttpNotFound();
            }
            

            return View(mascota.gestionVacunacion.ToList());
        }

        // GET: GestionVacunacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestionVacunacion gestionVacunacion = db.GestionVacunacions.Find(id);
            if (gestionVacunacion == null)
            {
                return HttpNotFound();
            }
            return View(gestionVacunacion);
        }

        // GET: GestionVacunacions/Create
        public ActionResult Create(string id)
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
            ViewBag.mascota = mascota;
            

            GestionVacunacion vacuna = new GestionVacunacion();
            vacuna.fechaVacunacion = DateTime.Today;
            return View(vacuna);
        }

        // POST: GestionVacunacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( GestionVacunacion gestionVacunacion)
        {
            if (ModelState.IsValid)
            {
                db.GestionVacunacions.Add(gestionVacunacion);
                db.SaveChanges();
                return RedirectToAction("Index/"+gestionVacunacion.mascotaID);
            }

            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre");
            return View(gestionVacunacion);
        }

        // GET: GestionVacunacions/Edit/5
        public ActionResult Edit(int?  id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestionVacunacion gestionVacunacion = db.GestionVacunacions.Find(id);
            if (gestionVacunacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre");
            return View(gestionVacunacion);
        }

        // POST: GestionVacunacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vacunaID,nombre,fechaVacunacion,dosis,lote,mascotaID")] GestionVacunacion gestionVacunacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestionVacunacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre");
            return View(gestionVacunacion);
        }

        // GET: GestionVacunacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestionVacunacion gestionVacunacion = db.GestionVacunacions.Find(id);
            if (gestionVacunacion == null)
            {
                return HttpNotFound();
            }
            return View(gestionVacunacion);
        }

        // POST: GestionVacunacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GestionVacunacion gestionVacunacion = db.GestionVacunacions.Find(id);
            db.GestionVacunacions.Remove(gestionVacunacion);
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
