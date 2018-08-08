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
    public class Auto_ConsentimientoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Auto_Consentimiento
        public ActionResult Index()
        {
            var auto_Consentimiento = db.Auto_Consentimiento.Include(a => a.historiaFK);
            return View(auto_Consentimiento.ToList());
        }

        // GET: Auto_Consentimiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto_Consentimiento auto_Consentimiento = db.Auto_Consentimiento.Find(id);
            if (auto_Consentimiento == null)
            {
                return HttpNotFound();
            }
            return View(auto_Consentimiento);
        }

        // GET: Auto_Consentimiento/Create
        public ActionResult Create()
        {
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id");
            return View();
        }

        // POST: Auto_Consentimiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,valor,interes,fecha,historia")] Auto_Consentimiento auto_Consentimiento)
        {
            if (ModelState.IsValid)
            {
                db.Auto_Consentimiento.Add(auto_Consentimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", auto_Consentimiento.historia);
            return View(auto_Consentimiento);
        }

        // GET: Auto_Consentimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto_Consentimiento auto_Consentimiento = db.Auto_Consentimiento.Find(id);
            if (auto_Consentimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", auto_Consentimiento.historia);
            return View(auto_Consentimiento);
        }

        // POST: Auto_Consentimiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,valor,interes,fecha,historia")] Auto_Consentimiento auto_Consentimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto_Consentimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", auto_Consentimiento.historia);
            return View(auto_Consentimiento);
        }

        // GET: Auto_Consentimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto_Consentimiento auto_Consentimiento = db.Auto_Consentimiento.Find(id);
            if (auto_Consentimiento == null)
            {
                return HttpNotFound();
            }
            return View(auto_Consentimiento);
        }

        // POST: Auto_Consentimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auto_Consentimiento auto_Consentimiento = db.Auto_Consentimiento.Find(id);
            db.Auto_Consentimiento.Remove(auto_Consentimiento);
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
