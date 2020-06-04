using admindx.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace admindx.Controllers
{
    public class usuario_perfilController : Controller
    {
        private gdocxEntities db = new gdocxEntities();

        // GET: usuario_perfil
        public ActionResult Index()
        {
            var p_usuario_perfil = db.p_usuario_perfil.Include(p => p.p_proyecto).Include(p => p.p_usuario);
            return View(p_usuario_perfil.ToList());
        }

        // GET: usuario_perfil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_usuario_perfil p_usuario_perfil = db.p_usuario_perfil.Find(id);
            if (p_usuario_perfil == null)
            {
                return HttpNotFound();
            }
            return View(p_usuario_perfil);
        }

        // GET: usuario_perfil/Create
        public ActionResult Create()
        {
            ViewBag.id_proyecto = new SelectList(db.p_proyecto, "id", "nom_proyecto");
            ViewBag.id_usuario = new SelectList(db.p_usuario, "id", "nombres");
            return View();
        }

        // POST: usuario_perfil/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_usuario,id_proyecto,superadmin,web_admin,web_consulta,loc_admin,loc_index,loc_calidad,loc_consulta")] p_usuario_perfil p_usuario_perfil)
        {
            if (ModelState.IsValid)
            {
                db.p_usuario_perfil.Add(p_usuario_perfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_proyecto = new SelectList(db.p_proyecto, "id", "nom_proyecto", p_usuario_perfil.id_proyecto);
            ViewBag.id_usuario = new SelectList(db.p_usuario, "id", "nombres", p_usuario_perfil.id_usuario);
            return View(p_usuario_perfil);
        }

        // GET: usuario_perfil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_usuario_perfil p_usuario_perfil = db.p_usuario_perfil.Find(id);
            if (p_usuario_perfil == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_proyecto = new SelectList(db.p_proyecto, "id", "nom_proyecto", p_usuario_perfil.id_proyecto);
            ViewBag.id_usuario = new SelectList(db.p_usuario, "id", "nombres", p_usuario_perfil.id_usuario);
            return View(p_usuario_perfil);
        }

        // POST: usuario_perfil/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_usuario,id_proyecto,superadmin,web_admin,web_consulta,loc_admin,loc_index,loc_calidad,loc_consulta")] p_usuario_perfil p_usuario_perfil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_usuario_perfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_proyecto = new SelectList(db.p_proyecto, "id", "nom_proyecto", p_usuario_perfil.id_proyecto);
            ViewBag.id_usuario = new SelectList(db.p_usuario, "id", "nombres", p_usuario_perfil.id_usuario);
            return View(p_usuario_perfil);
        }

        // GET: usuario_perfil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_usuario_perfil p_usuario_perfil = db.p_usuario_perfil.Find(id);
            if (p_usuario_perfil == null)
            {
                return HttpNotFound();
            }
            return View(p_usuario_perfil);
        }

        // POST: usuario_perfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_usuario_perfil p_usuario_perfil = db.p_usuario_perfil.Find(id);
            db.p_usuario_perfil.Remove(p_usuario_perfil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult proyUsuarios(int? idproyecto)
        {
            if (idproyecto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var items = new object[] { "1", "Entidad", "TEXTO", "S" };

            var usuarios = db.p_usuario_perfil.Include("p_usuario").Where(d => d.id_proyecto == idproyecto && d.loc_index == 1).ToList();
            var items = new object[usuarios.Count() + 1];
            var ap = 1;
            var encontrado = false;
            /* VALOR POR DEFECTO */
            items[0] = new object[] { "0", "LOTE PÚBLICO" };

            foreach (var item in usuarios)
            {
                var myItems = new object[] { item.id_usuario, item.p_usuario.usuario };
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