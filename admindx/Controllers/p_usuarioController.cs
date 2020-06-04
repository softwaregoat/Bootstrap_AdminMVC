using admindx.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admindx.Controllers
{
    public class p_usuarioController : Controller
    {
        private gdocxEntities db = new gdocxEntities();
        // GET: p_usuario
        public ActionResult Index()
        {
            var users = db.p_usuario.ToList();
            int index = 0;
            foreach (var user in users)
            {
                p_usuario_perfil perfile = db.p_usuario_perfil.Where(p => p.id_usuario == user.id).FirstOrDefault();
                if (perfile==null)
                {
                    perfile = new p_usuario_perfil();
                }
                users[index].perfil = perfile;
                index++;
            }
            return View(users);
        }

        // GET: p_usuario/Details/5
        public ActionResult Details(int id)
        {
            p_usuario_perfil perfile = db.p_usuario_perfil.Where(p => p.id_usuario == id).FirstOrDefault();
            if (perfile == null)
            {
                perfile = new p_usuario_perfil();
            }
            var user = db.p_usuario.Find(id);
            user.perfil = perfile;
            return View(user);
        }

        // GET: p_usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: p_usuario/Create
        [HttpPost]
        public ActionResult Create(p_usuario p_Usuario)
        {
            try
            {
                // TODO: Add insert logic here
                db.p_usuario.Add(p_Usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: p_usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var user = db.p_usuario.Find(id);
            return View(user);
        }

        // POST: p_usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(p_usuario p_Usuario)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(p_Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(p_Usuario);
            }
        }

        // GET: p_usuario/Delete/5
        public ActionResult Delete(int id)
        {
            var user = db.p_usuario.Find(id);
            return View(user);
        }

        // POST: p_usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, p_usuario p_Usuario)
        {
            try
            {
                // TODO: Add delete logic here
                p_Usuario = db.p_usuario.Find(id);
                if (p_Usuario!=null)
                {
                    db.p_usuario.Remove(p_Usuario);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(p_Usuario);
            }
        }
    }
}
