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
    public class p_subserieController : Controller
    {
        private gdocxEntities db = new gdocxEntities();

        // GET: p_subserie
        public ActionResult Index()
        {
            var p_subserie = db.p_subserie.Include(p => p.p_serie);
            return View(p_subserie.ToList());
        }

        // GET: p_subserie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_subserie p_subserie = db.p_subserie.Find(id);
            if (p_subserie == null)
            {
                return HttpNotFound();
            }
            return View(p_subserie);
        }

        // GET: p_subserie/Create
        public ActionResult Create()
        {
            ViewBag.id_serie = new SelectList(db.p_serie, "id", "codigo");
            return View();
        }

        // POST: p_subserie/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_serie,codigo,nombre")] p_subserie p_subserie)
        {
            if (ModelState.IsValid)
            {
                db.p_subserie.Add(p_subserie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_serie = new SelectList(db.p_serie, "id", "codigo", p_subserie.id_serie);
            return View(p_subserie);
        }

        // GET: p_subserie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_subserie p_subserie = db.p_subserie.Find(id);
            if (p_subserie == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_serie = new SelectList(db.p_serie, "id", "codigo", p_subserie.id_serie);
            return View(p_subserie);
        }

        // POST: p_subserie/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_serie,codigo,nombre")] p_subserie p_subserie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_subserie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_serie = new SelectList(db.p_serie, "id", "codigo", p_subserie.id_serie);
            return View(p_subserie);
        }

        // GET: p_subserie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_subserie p_subserie = db.p_subserie.Find(id);
            if (p_subserie == null)
            {
                return HttpNotFound();
            }
            return View(p_subserie);
        }

        // POST: p_subserie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_subserie p_subserie = db.p_subserie.Find(id);
            db.p_subserie.Remove(p_subserie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult proysuberie(int? idproyecto)
        {
            if (idproyecto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var subSeries = from b in db.p_subserie
                                 join s in db.p_serie on b.id_serie equals s.id 
                                 join o in db.p_organizacion on s.id_organizacion equals o.id_empresa into table1
                                 from o in table1.ToList()
                                 join p in db.p_proyecto on o.id_empresa equals p.id_empresa where p.id == idproyecto
                                 from i in table1.ToList()
                                 select (new IdNombre
                                 {
                                     id = b.id,
                                     nombre = b.nombre
                                 });
            var items = new object[subSeries.Count()];
            var ap = 0;
            var encontrado = false;

            foreach (var item in subSeries)
            {
                var myItems = new object[] { item.id, item.nombre };
                items[ap] = myItems;
                ap++;
            }
            if (ap > 0) encontrado = true;
            var miJson = new object[]
            {
                new { encontrado = encontrado},
                new { items = items}
            };

            return Json(miJson, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
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
