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
    public class Auto_NecropsiaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Auto_Necropsia
        public ActionResult Index()
        {
            var auto_Necropsia = db.Auto_Necropsia.Include(a => a.historiaFK);
            return View(auto_Necropsia.ToList());
        }

        // GET: Auto_Necropsia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto_Necropsia auto_Necropsia = db.Auto_Necropsia.Find(id);
            if (auto_Necropsia == null)
            {
                return HttpNotFound();
            }
            return View(auto_Necropsia);
        }

        // GET: Auto_Necropsia/Create
        public ActionResult Create()
        {
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id");
            return View();
        }

        // POST: Auto_Necropsia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Diagnostico,fecha,historia")] Auto_Necropsia auto_Necropsia)
        {
            if (ModelState.IsValid)
            {
                db.Auto_Necropsia.Add(auto_Necropsia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", auto_Necropsia.historia);
            return View(auto_Necropsia);
        }

        // GET: Auto_Necropsia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto_Necropsia auto_Necropsia = db.Auto_Necropsia.Find(id);
            if (auto_Necropsia == null)
            {
                return HttpNotFound();
            }
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", auto_Necropsia.historia);
            return View(auto_Necropsia);
        }

        // POST: Auto_Necropsia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Diagnostico,fecha,historia")] Auto_Necropsia auto_Necropsia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto_Necropsia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", auto_Necropsia.historia);
            return View(auto_Necropsia);
        }

        // GET: Auto_Necropsia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto_Necropsia auto_Necropsia = db.Auto_Necropsia.Find(id);
            if (auto_Necropsia == null)
            {
                return HttpNotFound();
            }
            return View(auto_Necropsia);
        }

        // POST: Auto_Necropsia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auto_Necropsia auto_Necropsia = db.Auto_Necropsia.Find(id);
            db.Auto_Necropsia.Remove(auto_Necropsia);
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
