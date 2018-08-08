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
    public class Auto_EutanasiaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Auto_Eutanasia
        public ActionResult Index()
        {
            var auto_Eutanasia = db.Auto_Eutanasia.Include(a => a.historiaFK);
            return View(auto_Eutanasia.ToList());
        }

        // GET: Auto_Eutanasia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto_Eutanasia auto_Eutanasia = db.Auto_Eutanasia.Find(id);
            if (auto_Eutanasia == null)
            {
                return HttpNotFound();
            }
            return View(auto_Eutanasia);
        }

        // GET: Auto_Eutanasia/Create
        public ActionResult Create()
        {
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id");
            return View();
        }

        // POST: Auto_Eutanasia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,causa,seccion,fecha,historia")] Auto_Eutanasia auto_Eutanasia)
        {
            if (ModelState.IsValid)
            {
                db.Auto_Eutanasia.Add(auto_Eutanasia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", auto_Eutanasia.historia);
            return View(auto_Eutanasia);
        }

        // GET: Auto_Eutanasia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto_Eutanasia auto_Eutanasia = db.Auto_Eutanasia.Find(id);
            if (auto_Eutanasia == null)
            {
                return HttpNotFound();
            }
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", auto_Eutanasia.historia);
            return View(auto_Eutanasia);
        }

        // POST: Auto_Eutanasia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,causa,seccion,fecha,historia")] Auto_Eutanasia auto_Eutanasia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto_Eutanasia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", auto_Eutanasia.historia);
            return View(auto_Eutanasia);
        }

        // GET: Auto_Eutanasia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto_Eutanasia auto_Eutanasia = db.Auto_Eutanasia.Find(id);
            if (auto_Eutanasia == null)
            {
                return HttpNotFound();
            }
            return View(auto_Eutanasia);
        }

        // POST: Auto_Eutanasia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auto_Eutanasia auto_Eutanasia = db.Auto_Eutanasia.Find(id);
            db.Auto_Eutanasia.Remove(auto_Eutanasia);
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
