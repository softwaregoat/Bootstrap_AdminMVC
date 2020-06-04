using admindx.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace admindx.Controllers
{
    public class p_proyectoController : Controller
    {
        private gdocxEntities db = new gdocxEntities();
        // GET: p_proyecto
        public ActionResult Index()
        {
            return View(db.p_proyecto.ToList());
        }

        // GET: p_proyecto/Details/5
        public ActionResult Details(int id)
        {
            p_proyecto p_Proyecto = db.p_proyecto.Find(id);
            return View(p_Proyecto);
        }

        // GET: p_proyecto/Create
        public ActionResult Create()
        {
            p_proyecto p_Proyecto = new p_proyecto();
            p_Proyecto.id_empresas = db.p_organizacion.Select(p=>p.id_empresa).ToList();
            return View(p_Proyecto);
        }

        // POST: p_proyecto/Create
        [HttpPost]
        public ActionResult Create(p_proyecto p_Proyecto)
        {
            try
            {
                // TODO: Add insert logic here
                db.p_proyecto.Add(p_Proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: p_proyecto/Edit/5
        public ActionResult Edit(int id)
        {
            p_proyecto p_Proyecto = db.p_proyecto.Find(id);
            p_Proyecto.id_empresas = db.p_organizacion.Select(p=>p.id_empresa).ToList();
            return View(p_Proyecto);
        }

        // POST: p_proyecto/Edit/5
        [HttpPost]
        public ActionResult Edit(p_proyecto p_Proyecto)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(p_Proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: p_proyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_proyecto p_proyecto = db.p_proyecto.Find(id);
            if (p_proyecto == null)
            {
                return HttpNotFound();
            }
            return View(p_proyecto);
        }

        // POST: p_proyecto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                p_proyecto p_proyecto = db.p_proyecto.Find(id);
                db.p_proyecto.Remove(p_proyecto);
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
