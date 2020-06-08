using admindx.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admindx.Controllers
{
    public class p_usuario_perfilController : Controller
    {
        private gdocxEntities db = new gdocxEntities();
        // GET: p_usuario_perfil
        public ActionResult Index()
        {
            return RedirectToAction("Index", "p_usuario");
        }

        // GET: p_usuario_perfil/Details/5
        public ActionResult Details(int id)
        {
            if (id > 0)
            {
                p_usuario_perfil perfil = db.p_usuario_perfil.Find(id);
                return View(perfil);
            }
            return RedirectToAction("Index");
        }

        // GET: p_usuario_perfil/Create
        public ActionResult Create()
        {
            p_usuario_perfil perfil = new p_usuario_perfil();
            return View(perfil);
        }

        // POST: p_usuario_perfil/Create
        [HttpPost]
        public ActionResult Create(p_usuario_perfil perfil)
        {
            try
            {
                // TODO: Add insert logic here
                db.p_usuario_perfil.Add(perfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: p_usuario_perfil/Edit/5
        public ActionResult Edit(int id)
        {
            if (id>0)
            {
                p_usuario_perfil perfil = db.p_usuario_perfil.Find(id);
                return View(perfil);
            }
            return RedirectToAction("Index");
        }

        // POST: p_usuario_perfil/Edit/5
        [HttpPost]
        public ActionResult Edit(p_usuario_perfil perfil)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(perfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: p_usuario_perfil/Delete/5
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                p_usuario_perfil perfil = db.p_usuario_perfil.Find(id);
                return View(perfil);
            }
            return RedirectToAction("Index");
        }

        // POST: p_usuario_perfil/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                p_usuario_perfil perfil = db.p_usuario_perfil.Find(id);
                db.p_usuario_perfil.Remove(perfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
