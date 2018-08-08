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
    public class RemisionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Remisiones
        public ActionResult Index(int ? id)
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


            return View(mascota.remisiones.ToList());
        }

        // GET: Remisiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remision remision = db.Remisions.Find(id);
            if (remision == null)
            {
                return HttpNotFound();
            }
            return View(remision);
        }

        // GET: Remisiones/Create
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


            Remision remision = new Remision();
            remision.fechaRemision = DateTime.Today;
            return View(remision);
        }

        // POST: Remisiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "remisionID,mascotaID,practicanteID,region,vista,diagnostico,ecografia,evaluacion,resultado,observacion")] Remision remision)
        {
            if (ModelState.IsValid)
            {
                db.Remisions.Add(remision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre", remision.mascotaID);
           ////** ViewBag.practicanteID = new SelectList(db.Mascotas, "id", "nombre", remision.practicanteID);
            return View(remision);
        }

        // GET: Remisiones/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remision remision = db.Remisions.Find(id);
            if (remision == null)
            {
                return HttpNotFound();
            }
            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre", remision.mascotaID);
          //////**  ViewBag.practicanteID = new SelectList(db.Mascotas, "id", "nombre", remision.practicanteID);
            return View(remision);
        }

        // POST: Remisiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "remisionID,mascotaID,practicanteID,region,vista,diagnostico,ecografia,evaluacion,resultado,observacion")] Remision remision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(remision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre", remision.mascotaID);
           //** ViewBag.practicanteID = new SelectList(db.Mascotas, "id", "nombre", remision.practicanteID);
            return View(remision);
        }

        // GET: Remisiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remision remision = db.Remisions.Find(id);
            if (remision == null)
            {
                return HttpNotFound();
            }
            return View(remision);
        }

        // POST: Remisiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Remision remision = db.Remisions.Find(id);
            db.Remisions.Remove(remision);
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
