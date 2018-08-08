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
    public class PlanTerapeuticoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlanTerapeutico
        public ActionResult Index()
        {
            var planTerapeuticoes = db.PlanTerapeuticoes.Include(p => p.monitoreo);
            return View(planTerapeuticoes.ToList());
        }

        // GET: PlanTerapeutico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanTerapeutico planTerapeutico = db.PlanTerapeuticoes.Find(id);
            if (planTerapeutico == null)
            {
                return HttpNotFound();
            }
            return View(planTerapeutico);
        }

        // GET: PlanTerapeutico/Create
        public ActionResult Create()
        {
            ViewBag.monitoreoFk = new SelectList(db.Monitoreos, "id", "historia");
            return View();
        }

        // POST: PlanTerapeutico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanTerapeutico planTerapeutico)
        {
            if (ModelState.IsValid)
            {
                planTerapeutico.fecha_hora = DateTime.Now;
                db.PlanTerapeuticoes.Add(planTerapeutico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.monitoreoFk = new SelectList(db.Monitoreos, "id", "historia", planTerapeutico.monitoreoFk);
            return View(planTerapeutico);
        }

        // GET: PlanTerapeutico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanTerapeutico planTerapeutico = db.PlanTerapeuticoes.Find(id);
            if (planTerapeutico == null)
            {
                return HttpNotFound();
            }
            ViewBag.monitoreoFk = new SelectList(db.Monitoreos, "id", "historia", planTerapeutico.monitoreoFk);
            return View(planTerapeutico);
        }

        // POST: PlanTerapeutico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha_hora,tipo,nombre,observacion,monitoreoFk")] PlanTerapeutico planTerapeutico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planTerapeutico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.monitoreoFk = new SelectList(db.Monitoreos, "id", "historia", planTerapeutico.monitoreoFk);
            return View(planTerapeutico);
        }

        // GET: PlanTerapeutico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanTerapeutico planTerapeutico = db.PlanTerapeuticoes.Find(id);
            if (planTerapeutico == null)
            {
                return HttpNotFound();
            }
            return View(planTerapeutico);
        }

        // POST: PlanTerapeutico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanTerapeutico planTerapeutico = db.PlanTerapeuticoes.Find(id);
            db.PlanTerapeuticoes.Remove(planTerapeutico);
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
