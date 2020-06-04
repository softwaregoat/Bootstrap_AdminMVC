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
    public class p_dependenciaController : Controller
    {
        private gdocxEntities db = new gdocxEntities();

        // GET: p_dependencia
        public ActionResult Index()
        {
            var p_dependencia = db.p_dependencia.Include(p => p.p_organizacion);
            return View(p_dependencia.ToList());
        }

        // GET: p_dependencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_dependencia p_dependencia = db.p_dependencia.Find(id);
            if (p_dependencia == null)
            {
                return HttpNotFound();
            }
            return View(p_dependencia);
        }

        // GET: p_dependencia/Create
        public ActionResult Create()
        {
            ViewBag.id_organizacion = new SelectList(db.p_organizacion, "id_empresa", "nombre");
            return View();
        }

        // POST: p_dependencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,nombre,estado,und_administrativa,id_organizacion")] p_dependencia p_dependencia)
        {
            if (ModelState.IsValid)
            {
                db.p_dependencia.Add(p_dependencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_organizacion = new SelectList(db.p_organizacion, "id_empresa", "nombre", p_dependencia.id_organizacion);
            return View(p_dependencia);
        }

        // GET: p_dependencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_dependencia p_dependencia = db.p_dependencia.Find(id);
            if (p_dependencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_organizacion = new SelectList(db.p_organizacion, "id_empresa", "nombre", p_dependencia.id_organizacion);
            return View(p_dependencia);
        }

        // POST: p_dependencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,nombre,estado,und_administrativa,id_organizacion")] p_dependencia p_dependencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_dependencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_organizacion = new SelectList(db.p_organizacion, "id_empresa", "nombre", p_dependencia.id_organizacion);
            return View(p_dependencia);
        }

        // GET: p_dependencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_dependencia p_dependencia = db.p_dependencia.Find(id);
            if (p_dependencia == null)
            {
                return HttpNotFound();
            }
            return View(p_dependencia);
        }

        // POST: p_dependencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_dependencia p_dependencia = db.p_dependencia.Find(id);
            db.p_dependencia.Remove(p_dependencia);
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
