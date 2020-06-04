using admindx.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admindx.Controllers
{
    public class p_recursoController : Controller
    {
        private gdocxEntities db = new gdocxEntities();
        // GET: p_recurso
        public ActionResult Index()
        {
            return View(db.p_recurso.ToList());
        }

        // GET: p_recurso/Details/5
        public ActionResult Details(int id)
        {
            return View(db.p_recurso.Find(id));
        }

        // GET: p_recurso/Create
        public ActionResult Create()
        {
            p_recurso p_Recurso = new p_recurso();
            p_Recurso.id_proyectos = db.p_proyecto.Select(p => p.id).ToList();
            return View(p_Recurso);
        }

        // POST: p_recurso/Create
        [HttpPost]
        public ActionResult Create(p_recurso p_Recurso)
        {
            try
            {
                // TODO: Add insert logic here
                db.p_recurso.Add(p_Recurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                var e = ex;
                p_Recurso.id_proyectos = db.p_proyecto.Select(p => p.id).ToList();
                return View(p_Recurso);
            }
        }

        // GET: p_recurso/Edit/5
        public ActionResult Edit(int id)
        {
            p_recurso p_Recurso = db.p_recurso.Find(id);
            p_Recurso.id_proyectos = db.p_proyecto.Select(p => p.id).ToList();
            return View(p_Recurso);
        }

        // POST: p_recurso/Edit/5
        [HttpPost]
        public ActionResult Edit(p_recurso p_Recurso)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(p_Recurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: p_recurso/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.p_recurso.Find(id));
        }

        // POST: p_recurso/Delete/5
        [HttpPost]
        public ActionResult Delete(p_recurso p_Recurso)
        {
            try
            {
                // TODO: Add delete logic here
                p_Recurso = db.p_recurso.Find(p_Recurso.id);
                db.p_recurso.Remove(p_Recurso);
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
