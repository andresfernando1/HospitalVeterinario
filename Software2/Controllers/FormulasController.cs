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
    public class FormulasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Formulas
        public ActionResult Index( int ? id)
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


            return View(mascota.formulas.ToList());
        }

        // GET: Formulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formula formula = db.Formulae.Find(id);
            if (formula == null)
            {
                return HttpNotFound();
            }
            return View(formula);
        }

        // GET: Formulas/Create
        public ActionResult Create()
        {
            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre");
            //////////////ViewBag.practicanteID = new SelectList(db.Practicantes, "practicanteID", "nombre");

            Formula formula = new Formula();
            formula.fecha = DateTime.Today;
            return View(formula);


        }


        // POST: Formulas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "formulaID,mascotaID,fecha,practicanteID")] Formula formula)
        {
            if (ModelState.IsValid)
            {
                db.Formulae.Add(formula);
                db.SaveChanges();
                

                return RedirectToAction("Index");
            }

            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre", formula.mascotaID);
      ///////*      ViewBag.practicanteID = new SelectList(db.Practicantes, "practicanteID", "nombre", formula.practicanteID);
            return View(formula);
        }

        // GET: Formulas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formula formula = db.Formulae.Find(id);
            if (formula == null)
            {
                return HttpNotFound();
            }
            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre", formula.mascotaID);
         //////////////*   ViewBag.practicanteID = new SelectList(db.Practicantes, "practicanteID", "nombre", formula.practicanteID);
            return View(formula);
        }

        // POST: Formulas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "formulaID,mascotaID,fecha,practicanteID")] Formula formula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mascotaID = new SelectList(db.Mascotas, "id", "nombre", formula.mascotaID);
         //////**   ViewBag.practicanteID = new SelectList(db.Practicantes, "practicanteID", "nombre", formula.practicanteID);
            return View(formula);
        }

        // GET: Formulas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formula formula = db.Formulae.Find(id);
            if (formula == null)
            {
                return HttpNotFound();
            }
            return View(formula);
        }

        // POST: Formulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formula formula = db.Formulae.Find(id);
            db.Formulae.Remove(formula);
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
