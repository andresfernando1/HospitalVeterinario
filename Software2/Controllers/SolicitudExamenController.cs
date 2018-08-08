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
    public class SolicitudExamenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SolicitudExamen
        public ActionResult Index()
        {
            var solicitudExamen = db.SolicitudExamen.Include(s => s.mascotaFK);
            return View(solicitudExamen.ToList());
        }

        // GET: SolicitudExamen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudExamen solicitudExamen = db.SolicitudExamen.Find(id);
            if (solicitudExamen == null)
            {
                return HttpNotFound();
            }
            return View(solicitudExamen);
        }

        // GET: SolicitudExamen/Create
        public ActionResult Create()
        {
            ViewBag.mascota = new SelectList(db.Mascotas, "id", "nombre");
         /////**   ViewBag.idPracticante = new SelectList(db.Practicantes, "practicanteID", "nombre");
            return View();
        }

        // POST: SolicitudExamen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,numeroRecibo,mascota,muestraRemitida,examenSolicitado,diagnosticoPresuntivo,idPracticante")] SolicitudExamen solicitudExamen)
        {
            if (ModelState.IsValid)
            {
                db.SolicitudExamen.Add(solicitudExamen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mascota = new SelectList(db.Mascotas, "id", "nombre", solicitudExamen.mascota);
           ////***** ViewBag.idPracticante = new SelectList(db.Practicantes, "practicanteID", "nombre", solicitudExamen.idPracticante);
            return View(solicitudExamen);
        }

        // GET: SolicitudExamen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudExamen solicitudExamen = db.SolicitudExamen.Find(id);
            if (solicitudExamen == null)
            {
                return HttpNotFound();
            }
            ViewBag.mascota = new SelectList(db.Mascotas, "id", "nombre", solicitudExamen.mascota);
           ////*** ViewBag.idPracticante = new SelectList(db.Practicantes, "practicanteID", "nombre", solicitudExamen.idPracticante);
            return View(solicitudExamen);
        }

        // POST: SolicitudExamen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,numeroRecibo,mascota,muestraRemitida,examenSolicitado,diagnosticoPresuntivo,idPracticante")] SolicitudExamen solicitudExamen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitudExamen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mascota = new SelectList(db.Mascotas, "id", "nombre", solicitudExamen.mascota);
           ////** ViewBag.idPracticante = new SelectList(db.Practicantes, "practicanteID", "nombre", solicitudExamen.idPracticante);
            return View(solicitudExamen);
        }

        // GET: SolicitudExamen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudExamen solicitudExamen = db.SolicitudExamen.Find(id);
            if (solicitudExamen == null)
            {
                return HttpNotFound();
            }
            return View(solicitudExamen);
        }

        // POST: SolicitudExamen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitudExamen solicitudExamen = db.SolicitudExamen.Find(id);
            db.SolicitudExamen.Remove(solicitudExamen);
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
