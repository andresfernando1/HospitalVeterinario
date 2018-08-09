using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Software2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Software2.Controllers
{
    [Authorize]
    public class PracticantesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Practicantes
        public ActionResult Index()
        {
            return View(db.Veterinarios.Where(xx=>xx.role=="Practicante"));
        }


        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinario veterinario = db.Veterinarios.Find(id);
            if (veterinario == null)
            {
                return HttpNotFound();
            }
            return View(veterinario);
        }

        // POST: Propietarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Veterinario veterinario = db.Veterinarios.Find(id);
            db.Veterinarios.Remove(veterinario);
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

        private bool existePracticante(String correo)
        {
            return db.Users.Count(x => x.Email == correo) > 0;
        }
    }
}
