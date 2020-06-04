using admindx.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace admindx
{
    public class p_organizacionController : Controller
    {
        private gdocxEntities db = new gdocxEntities();

        // GET: p_organizacion
        public ActionResult Index()
        {
            return View(db.p_organizacion.ToList());
        }

        // GET: p_organizacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_organizacion p_organizacion = db.p_organizacion.Find(id);
            if (p_organizacion == null)
            {
                return HttpNotFound();
            }
            return View(p_organizacion);
        }

        // GET: p_organizacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: p_organizacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_empresa,nombre,activo")] p_organizacion p_organizacion)
        {
            if (ModelState.IsValid)
            {
                db.p_organizacion.Add(p_organizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_organizacion);
        }

        // GET: p_organizacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_organizacion p_organizacion = db.p_organizacion.Find(id);
            if (p_organizacion == null)
            {
                return HttpNotFound();
            }
            return View(p_organizacion);
        }

        // POST: p_organizacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_empresa,nombre,activo")] p_organizacion p_organizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_organizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_organizacion);
        }

        // GET: p_organizacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_organizacion p_organizacion = db.p_organizacion.Find(id);
            if (p_organizacion == null)
            {
                return HttpNotFound();
            }
            return View(p_organizacion);
        }

        // POST: p_organizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_organizacion p_organizacion = db.p_organizacion.Find(id);
            db.p_organizacion.Remove(p_organizacion);
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