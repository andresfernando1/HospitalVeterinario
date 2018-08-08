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
    public class EspeciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Especies
        public ActionResult Index()
        {
            return View(db.Especies.ToList());
            //holi muchachos
        }

        // GET: Especies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie especie = db.Especies.Find(id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        // GET: Especies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] Especie especie)
        {
            if (existEspecie(especie.nombre))
            {
                ModelState.AddModelError("", "Ya existe una especie con este nombre");
                return View();
            }
            if (ModelState.IsValid)
            {
                db.Especies.Add(especie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especie);
        }

        // GET: Especies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie especie = db.Especies.Find(id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        // POST: Especies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] Especie especie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especie);
        }

        // GET: Especies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie especie = db.Especies.Find(id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        // POST: Especies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Especie especie = db.Especies.Find(id);
            db.Especies.Remove(especie);
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

        private bool existEspecie(String nombre)
        {
            return db.Especies.Count(x => x.nombre.ToUpper() == nombre.ToUpper()) > 0;
        }
    }
}
