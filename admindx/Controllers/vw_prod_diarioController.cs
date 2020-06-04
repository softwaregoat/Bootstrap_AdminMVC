using admindx.Models;
using OfficeOpenXml;
using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admindx.Controllers
{
    public class vw_prod_diarioController : Controller
    {
        private gdocxEntities db = new gdocxEntities();

        public static Boolean EsFecha(String fecha)
        {
            try
            {
                DateTime.Parse(fecha);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // GET: vw_prod_diario
        public ActionResult Index()
        {
            return View(db.vw_prod_diario.ToList());
        }

        // POST: vw_prod_diario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string SearchString)
        {
            var fecha = Request.Form["SearchString"].ToString();
            if (String.IsNullOrEmpty(fecha))
            {
                return View(db.vw_prod_diario.ToList());
            }
            else
            {
                if (EsFecha(fecha))
                {
                    DateTime fechaConsulta = DateTime.Parse(fecha);
                    var consulta = db.vw_prod_diario.Where(x => x.f_asignacion == fechaConsulta).ToList();
                    ViewBag.SearchString = SearchString;
                    if(consulta.Count>0) ViewBag.tipo = "ExportarExcel";
                    return View(consulta);
                }
            }
            return View(db.vw_prod_diario.ToList());
        }

        public ActionResult ExportExcel(string fechaReporte)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            db.Database.CommandTimeout = 900;
            DateTime fechaConsulta = DateTime.Parse(fechaReporte);
            var data = db.vw_prod_diario.Where(x => x.f_asignacion == fechaConsulta).ToList();
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Auditoría PDF");
            workSheet.Cells[1, 1].LoadFromCollection(data, true);
            using (var memoryStream = new MemoryStream())
            {
                var fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH-mm:-ss");
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=Reporte Diario " + fechaHora + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }

            return RedirectToAction("Index");
        }

        // GET: vw_prod_diario/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_prod_diario vw_prod_diario = db.vw_prod_diario.Find(id);
            if (vw_prod_diario == null)
            {
                return HttpNotFound();
            }
            return View(vw_prod_diario);
        }

        // GET: vw_prod_diario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vw_prod_diario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_proyecto,nom_lote,nro_caja,nro_expediente,asignado,Realizado,fecha,hora,nro_carpeta,tomo,folio_inicial,folio_final,registros,folio_total")] vw_prod_diario vw_prod_diario)
        {
            if (ModelState.IsValid)
            {
                db.vw_prod_diario.Add(vw_prod_diario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vw_prod_diario);
        }

        // GET: vw_prod_diario/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_prod_diario vw_prod_diario = db.vw_prod_diario.Find(id);
            if (vw_prod_diario == null)
            {
                return HttpNotFound();
            }
            return View(vw_prod_diario);
        }

        // POST: vw_prod_diario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_proyecto,nom_lote,nro_caja,nro_expediente,asignado,Realizado,fecha,hora,nro_carpeta,tomo,folio_inicial,folio_final,registros,folio_total")] vw_prod_diario vw_prod_diario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vw_prod_diario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vw_prod_diario);
        }

        // GET: vw_prod_diario/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_prod_diario vw_prod_diario = db.vw_prod_diario.Find(id);
            if (vw_prod_diario == null)
            {
                return HttpNotFound();
            }
            return View(vw_prod_diario);
        }

        // POST: vw_prod_diario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            vw_prod_diario vw_prod_diario = db.vw_prod_diario.Find(id);
            db.vw_prod_diario.Remove(vw_prod_diario);
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