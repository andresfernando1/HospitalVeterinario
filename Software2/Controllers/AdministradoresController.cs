using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Software2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Software2.Controllers
{
    public class AdministradoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administradores
        public ActionResult Index()
        {
            return View(db.Administradors.ToList());
        }



        // GET: Administradores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administradores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Administrador administrador)
        {

            if (existeAdmin(administrador.correo))
            {
                ModelState.AddModelError("", "Este correo ya se encuentra registrado");
                return View();
            }

            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    var UserManager = new UserManager<ApplicationUser>(
                        new UserStore<ApplicationUser>(db));

                    var user = new ApplicationUser()
                    {
                        Email = administrador.correo,
                        UserName = administrador.correo
                    };
                    var resultado = UserManager.Create(user, administrador.password);
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                    administrador.adminID = user.Id;


                }

           

                db.Administradors.Add(administrador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrador);
        }

        private bool existeAdmin(String correo)
        {
            return db.Users.Count(x => x.Email == correo) > 0;
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
