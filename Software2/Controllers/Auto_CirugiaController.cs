using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Software2.Models;
using Software2.Reportes;

namespace Software2.Controllers
{
    [Authorize]
    public class Auto_CirugiaController : Controller
        
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Auto_Cirugia
        public ActionResult Index()
        {
            var auto_Cirugia = db.Auto_Cirugia.Include(a => a.historiaFK);
            return View(auto_Cirugia.ToList());
        }

        // GET: Auto_Cirugia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto_Cirugia auto_Cirugia = db.Auto_Cirugia.Find(id);
            if (auto_Cirugia == null)
            {
                return HttpNotFound();
            }
            return View(auto_Cirugia);
        }

        // GET: Auto_Cirugia/Create
        public ActionResult Create(string id)
        {
            ViewBag.historia = id;
            Auto_Cirugia cirugia = new Auto_Cirugia();
            cirugia.historia= id;
            cirugia.fecha = DateTime.Now.Date;
            return View(cirugia);
        }

        // POST: Auto_Cirugia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Auto_Cirugia auto_Cirugia)
        {
            if (auto_Cirugia.historia!=null && auto_Cirugia.historia != "")
            {
                if (auto_Cirugia.fecha.Date < DateTime.Now.Date)
                {
                    ModelState.AddModelError("", "La fecha debe ser mayor o igual a la actual");
                }
                else
                {
                    db.Auto_Cirugia.Add(auto_Cirugia);
                    db.SaveChanges();
                    return RedirectToAction("Details", "HistoriaClinica", new { id = auto_Cirugia.historia });
                }
              
            }

           
            return View(auto_Cirugia);
        }

        // GET: Auto_Cirugia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto_Cirugia auto_Cirugia = db.Auto_Cirugia.Find(id);
            if (auto_Cirugia == null)
            {
                return HttpNotFound();
            }
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", auto_Cirugia.historia);
            return View(auto_Cirugia);
        }

        // POST: Auto_Cirugia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,observaciones,fecha,historia")] Auto_Cirugia auto_Cirugia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto_Cirugia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.historia = new SelectList(db.HistoriaClinicas, "id", "id", auto_Cirugia.historia);
            return View(auto_Cirugia);
        }

        // GET: Auto_Cirugia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto_Cirugia auto_Cirugia = db.Auto_Cirugia.Find(id);
            if (auto_Cirugia == null)
            {
                return HttpNotFound();
            }
            return View(auto_Cirugia);
        }

        // POST: Auto_Cirugia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auto_Cirugia auto_Cirugia = db.Auto_Cirugia.Find(id);
            db.Auto_Cirugia.Remove(auto_Cirugia);
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

       public ActionResult Report(Auto_Cirugia cirugia)
        {
           ReporteCirugia reporteCirugia = new ReporteCirugia();
            Debug.WriteLine(db.Auto_Cirugia.First().observaciones);
           byte[] abytes = reporteCirugia.PrepararReporte(db.Auto_Cirugia.First());
           return File(abytes, "application/pdf");

        }
    }
}
