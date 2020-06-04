using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admindx.Models;

namespace admindx.Controllers
{
    public class p_serieController : Controller
    {
        private gdocxEntities db = new gdocxEntities();

        // GET: p_serie
        public ActionResult Index()
        {
            var p_serie = db.p_serie.Include(p => p.p_organizacion);
            return View(p_serie.ToList());
        }

        // GET: p_serie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_serie p_serie = db.p_serie.Find(id);
            if (p_serie == null)
            {
                return HttpNotFound();
            }
            return View(p_serie);
        }

        // GET: p_serie/Create
        public ActionResult Create()
        {
            ViewBag.id_organizacion = new SelectList(db.p_organizacion, "id_empresa", "nombre");
            return View();
        }

        // POST: p_serie/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,nombre,id_organizacion")] p_serie p_serie)
        {
            if (ModelState.IsValid)
            {
                db.p_serie.Add(p_serie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_organizacion = new SelectList(db.p_organizacion, "id_empresa", "nombre", p_serie.id_organizacion);
            return View(p_serie);
        }

        // GET: p_serie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_serie p_serie = db.p_serie.Find(id);
            if (p_serie == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_organizacion = new SelectList(db.p_organizacion, "id_empresa", "nombre", p_serie.id_organizacion);
            return View(p_serie);
        }

        // POST: p_serie/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,nombre,id_organizacion")] p_serie p_serie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_serie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_organizacion = new SelectList(db.p_organizacion, "id_empresa", "nombre", p_serie.id_organizacion);
            return View(p_serie);
        }

        // GET: p_serie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_serie p_serie = db.p_serie.Find(id);
            if (p_serie == null)
            {
                return HttpNotFound();
            }
            return View(p_serie);
        }

        // POST: p_serie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_serie p_serie = db.p_serie.Find(id);
            db.p_serie.Remove(p_serie);
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
