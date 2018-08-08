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
    public class MonitoreoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Monitoreo
        public ActionResult Index()
        {
            var monitoreos = db.Monitoreos.Include(m => m.historia_clinica);
            return View(monitoreos.ToList());
        }

        // GET: Monitoreo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monitoreo monitoreo = db.Monitoreos.Find(id);
            if (monitoreo == null)
            {
                return HttpNotFound();
            }
            return View(monitoreo);
        }

        // GET: Monitoreo/Create
        public ActionResult Create()
        {
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id");
            return View();
        }

        // POST: Monitoreo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Monitoreo monitoreo)
        {
            if (ModelState.IsValid)
            {
                monitoreo.fecha = DateTime.Now.Date;
                db.Monitoreos.Add(monitoreo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", monitoreo.historia);
            return View(monitoreo);
        }

        // GET: Monitoreo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monitoreo monitoreo = db.Monitoreos.Find(id);
            if (monitoreo == null)
            {
                return HttpNotFound();
            }
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", monitoreo.historia);
            return View(monitoreo);
        }

        // POST: Monitoreo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,historia,peso")] Monitoreo monitoreo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monitoreo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", monitoreo.historia);
            return View(monitoreo);
        }

        // GET: Monitoreo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monitoreo monitoreo = db.Monitoreos.Find(id);
            if (monitoreo == null)
            {
                return HttpNotFound();
            }
            return View(monitoreo);
        }

        // POST: Monitoreo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Monitoreo monitoreo = db.Monitoreos.Find(id);
            db.Monitoreos.Remove(monitoreo);
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
