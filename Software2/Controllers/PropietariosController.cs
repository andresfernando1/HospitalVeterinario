using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Software2.Models;

namespace Software2.Controllers //Carlos Mario Jaramillo 
{
    [Authorize]
    public class PropietariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Propietarios
        public ActionResult Index()
        {
            return View(db.Propietarios.ToList());
        }

        // GET: Propietarios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = db.Propietarios.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // GET: Propietarios/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cedula,nombre,apellido,celular,correo")] Propietario propietario)
        {
            if (ExistPropietario(propietario.cedula))
            {
                ModelState.AddModelError("","El cliente ya existe");

                return View();

            }



            if (ModelState.IsValid)
            { 
                
                db.Propietarios.Add(propietario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propietario);
        }

        // GET: Propietarios/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = db.Propietarios.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cedula,nombre,apellido,celular,correo")] Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propietario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propietario);
        }

        // GET: Propietarios/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = db.Propietarios.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // POST: Propietarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Propietario propietario = db.Propietarios.Find(id);
            db.Propietarios.Remove(propietario);
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
        private bool ExistPropietario(long cedula)
        {
            return db.Propietarios.Count(x => x.cedula == cedula) > 0;
        }
        
    }
}
