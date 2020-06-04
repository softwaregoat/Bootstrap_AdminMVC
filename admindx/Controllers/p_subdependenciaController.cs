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
    public class p_subdependenciaController : Controller
    {
        private gdocxEntities db = new gdocxEntities();

        // GET: p_subdependencia
        public ActionResult Index()
        {
            var p_subdependencia = db.p_subdependencia.Include(p => p.p_dependencia);
            return View(p_subdependencia.ToList());
        }

        // GET: p_subdependencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_subdependencia p_subdependencia = db.p_subdependencia.Find(id);
            if (p_subdependencia == null)
            {
                return HttpNotFound();
            }
            return View(p_subdependencia);
        }

        // GET: p_subdependencia/Create
        public ActionResult Create()
        {
            ViewBag.id_dependencia = new SelectList(db.p_dependencia, "id", "codigo");
            return View();
        }

        // POST: p_subdependencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_dependencia,cod,nombre")] p_subdependencia p_subdependencia)
        {
            if (ModelState.IsValid)
            {
                db.p_subdependencia.Add(p_subdependencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_dependencia = new SelectList(db.p_dependencia, "id", "codigo", p_subdependencia.id_dependencia);
            return View(p_subdependencia);
        }

        // GET: p_subdependencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_subdependencia p_subdependencia = db.p_subdependencia.Find(id);
            if (p_subdependencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_dependencia = new SelectList(db.p_dependencia, "id", "codigo", p_subdependencia.id_dependencia);
            return View(p_subdependencia);
        }

        // POST: p_subdependencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_dependencia,cod,nombre")] p_subdependencia p_subdependencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_subdependencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_dependencia = new SelectList(db.p_dependencia, "id", "codigo", p_subdependencia.id_dependencia);
            return View(p_subdependencia);
        }

        // GET: p_subdependencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_subdependencia p_subdependencia = db.p_subdependencia.Find(id);
            if (p_subdependencia == null)
            {
                return HttpNotFound();
            }
            return View(p_subdependencia);
        }

        // POST: p_subdependencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_subdependencia p_subdependencia = db.p_subdependencia.Find(id);
            db.p_subdependencia.Remove(p_subdependencia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult proysubdependencia(int? idproyecto)
        {
            if (idproyecto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var subDependencias = from b in db.p_subdependencia
                                  join s in db.p_dependencia on b.id_dependencia equals s.id
                                  join o in db.p_organizacion on s.id_organizacion equals o.id_empresa into table1
                                  from o in table1.ToList()
                                  join p in db.p_proyecto on o.id_empresa equals p.id_empresa
                                  where p.id == idproyecto
                                  from i in table1.ToList()
                                  select (new IdNombre
                                  {
                                      id = b.id,
                                      nombre = b.nombre
                                  });
            var items = new object[subDependencias.Count()];
            var ap = 0;
            var encontrado = false;

            foreach (var item in subDependencias)
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
