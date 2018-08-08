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
    public class MonitoreoPacientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MonitoreoPacientes
        public ActionResult Index()
        {
            var monitoreoPacientes = db.MonitoreoPacientes.Include(m => m.monitoreo);
            return View(monitoreoPacientes.ToList());
        }

        // GET: MonitoreoPacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitoreoPacientes monitoreoPacientes = db.MonitoreoPacientes.Find(id);
            if (monitoreoPacientes == null)
            {
                return HttpNotFound();
            }
            return View(monitoreoPacientes);
        }

        // GET: MonitoreoPacientes/Create
        public ActionResult Create()
        {
            ViewBag.monitoreoFk = new SelectList(db.Monitoreos, "id", "historia");
            return View();
        }

        // POST: MonitoreoPacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MonitoreoPacientes monitoreoPacientes)
        {
            if (ModelState.IsValid)
            {
                monitoreoPacientes.fecha_hora = DateTime.Now;
                db.MonitoreoPacientes.Add(monitoreoPacientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.monitoreoFk = new SelectList(db.Monitoreos, "id", "historia", monitoreoPacientes.monitoreoFk);
            return View(monitoreoPacientes);
        }

        // GET: MonitoreoPacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitoreoPacientes monitoreoPacientes = db.MonitoreoPacientes.Find(id);
            if (monitoreoPacientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.monitoreoFk = new SelectList(db.Monitoreos, "id", "historia", monitoreoPacientes.monitoreoFk);
            return View(monitoreoPacientes);
        }

        // POST: MonitoreoPacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha_hora,temperatura,pulso,trc,fr,peritaltismo,mucosas,observacion,monitoreoFk")] MonitoreoPacientes monitoreoPacientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monitoreoPacientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.monitoreoFk = new SelectList(db.Monitoreos, "id", "historia", monitoreoPacientes.monitoreoFk);
            return View(monitoreoPacientes);
        }

        // GET: MonitoreoPacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitoreoPacientes monitoreoPacientes = db.MonitoreoPacientes.Find(id);
            if (monitoreoPacientes == null)
            {
                return HttpNotFound();
            }
            return View(monitoreoPacientes);
        }

        // POST: MonitoreoPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonitoreoPacientes monitoreoPacientes = db.MonitoreoPacientes.Find(id);
            db.MonitoreoPacientes.Remove(monitoreoPacientes);
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
