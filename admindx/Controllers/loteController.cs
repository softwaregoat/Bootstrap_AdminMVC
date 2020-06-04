using admindx.Models;
using ExcelDataReader;
using System;
using System.Collections;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace admindx.Controllers
{
    public class loteController : Controller
    {
        private gdocxEntities db = new gdocxEntities();

        // GET: lote
        public ActionResult Index()
        {
            var t_lote = db.t_lote.Include(t => t.p_proyecto).Include(t => t.p_subdependencia).Include(t => t.p_subserie);
            return View(t_lote.ToList());
        }

        // GET: lote/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_lote t_lote = db.t_lote.Find(id);
            if (t_lote == null)
            {
                return HttpNotFound();
            }
            return View(t_lote);
        }

        // GET: lote/Create
        public ActionResult Create()
        {
            ViewBag.id_proyecto = new SelectList(db.p_proyecto, "id", "nom_proyecto");
            return View();
        }

        public static string GeTxtHora()
        {
            string DateTime = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
            return DateTime;
        }

        private bool IsNumeric(string input)
        {
            int number;
            return int.TryParse(input, out number);
        }

        // POST: lote/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom_lote,id_subdependencia,id_subserie,id_proyecto,fecha_ingreso,marco")] t_lote t_lote, HttpPostedFileBase file, string[] asignacion)
        {
            Debug.WriteLine(asignacion);
            if (ModelState.IsValid)
            {
                if (t_lote.nom_lote == "" || t_lote.nom_lote == null)
                {
                    ModelState.AddModelError("errorNomLote", "No puede ser vacío");
                }
                else if (asignacion == null)
                {
                    ModelState.AddModelError("errorAsignacion", "Debe asignar el lote");
                }
                else if (file == null || file.ContentLength == 0)
                {
                    ModelState.AddModelError("errorArchivo", "Debe cargar un archivo CSV");
                }
                else
                {
                    //Crea carpeta si no existe
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                    //GuardaArchivo
                    var fileName = GeTxtHora() + "-" + file.FileName;
                    var ruta = Path.Combine(path, fileName);
                    file.SaveAs(ruta);
                    //Valida Archivo
                    //ABRIR ARCHIVO CSV
                    using (var stream = System.IO.File.Open(ruta, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateCsvReader(stream, new ExcelReaderConfiguration() { AutodetectSeparators = new char[] { ';' }, }))
                        {   // 2. Use the AsDataSet extension method
                            var result = reader.AsDataSet();
                            bool formatOk = false;
                            int contador = 0;
                            int sumFolios = 0;
                            int conFolios = 0;
                            foreach (DataRow dr in result.Tables[0].Rows)
                            {
                                if (!formatOk) formatOk = validarTitulos(dr);
                                if (formatOk)
                                {
                                    if (t_lote.id.ToString() == null || t_lote.id.ToString() == "" || t_lote.id.ToString() == "0")
                                    {   //Guarda Lote
                                        t_lote.fecha_ingreso = DateTime.Now;
                                        db.t_lote.Add(t_lote);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        t_carpeta miCarpeta = new t_carpeta();
                                        miCarpeta.id_lote = t_lote.id;
                                        miCarpeta.nro_expediente = dr[1].ToString();
                                        miCarpeta.nom_expediente = dr[2].ToString();
                                        miCarpeta.nro_caja = dr[0].ToString();
                                        if (IsNumeric(dr[3].ToString())) miCarpeta.nro_carpeta = Int32.Parse(dr[3].ToString());
                                        if (IsNumeric(dr[4].ToString()))
                                        {
                                            miCarpeta.total_folios = Int32.Parse(dr[4].ToString());
                                            sumFolios += Int32.Parse(dr[4].ToString());
                                            conFolios++;
                                        }
                                        miCarpeta.estado = 'D'.ToString();
                                        miCarpeta.ejecucion = 0;
                                        db.t_carpeta.Add(miCarpeta);
                                        db.SaveChanges();
                                    }
                                }
                                //Debug.Write(dr[0].ToString());
                                contador++;
                                if (!formatOk && contador == 5) break;
                            }
                            if (formatOk)
                            {
                                /*****  Realiza asignación se Trabajo   *****/
                                int posusuario = 0;
                                float promedioFolios = sumFolios / conFolios;
                                float cambio = sumFolios / asignacion.Length;
                                float tmpSumFolios = 0;
                                var carpetas = db.t_carpeta
                                .Select(u => new
                                {
                                    id = u.id,
                                    id_lote = u.id_lote,
                                    folios = u.total_folios
                                }).Where(h => h.id_lote == t_lote.id).ToList();
                                foreach (var carpeta in carpetas)
                                {
                                    if (asignacion[posusuario] != "0")
                                    {
                                        var Sql = "update t_carpeta set idusr_asignado = '" + asignacion[posusuario] + "' where id = " + carpeta.id;
                                        db.Database.ExecuteSqlCommand(Sql);
                                    }
                                    if (IsNumeric(carpeta.folios.ToString()))
                                    {
                                        tmpSumFolios += Int32.Parse(carpeta.folios.ToString());
                                    }
                                    else
                                    {
                                        tmpSumFolios += promedioFolios;//promedioFolios
                                    }
                                    if (tmpSumFolios > ((cambio * (1 + posusuario)) - (promedioFolios * 0.6))) posusuario++;
                                }
                                return RedirectToAction("Index");
                            }
                            else ModelState.AddModelError("errorArchivo", "Formato no valido, revise los encabezados y la información");
                        }
                    }
                }
            }

            ViewBag.id_proyecto = new SelectList(db.p_proyecto, "id", "nom_proyecto", t_lote.id_proyecto);
            return View(t_lote);
        }

        private bool validarTitulos(DataRow dr)
        {
            if (dr[0].ToString().Trim().ToUpper() != "CAJA") return false;
            if (dr[1].ToString().Trim().ToUpper() != "CARPETA") return false;
            if (dr[2].ToString().Trim().ToUpper() != "DESCRIPCION" && dr[2].ToString().Trim().ToUpper() != "DESCRIPCIÓN") return false;
            if (dr[3].ToString().Trim().ToUpper() != "NUM_CARPETA") return false;
            if (dr[4].ToString().Trim().ToUpper() != "FOLIOS") return false;
            return true;
        }

        // GET: lote/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_lote t_lote = db.t_lote.Find(id);
            if (t_lote == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_proyecto = new SelectList(db.p_proyecto, "id", "nom_proyecto", t_lote.id_proyecto);
            ViewBag.id_subdependencia = new SelectList(db.p_subdependencia, "id", "nombre", t_lote.id_subdependencia);
            ViewBag.id_subserie = new SelectList(db.p_subserie, "id", "nombre", t_lote.id_subserie);
            return View(t_lote);
        }

        // POST: lote/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom_lote,id_subdependencia,id_subserie,id_proyecto,fecha_ingreso,marco")] t_lote t_lote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_lote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_proyecto = new SelectList(db.p_proyecto, "id", "nom_proyecto", t_lote.id_proyecto);
            ViewBag.id_subdependencia = new SelectList(db.p_subdependencia, "id", "cod", t_lote.id_subdependencia);
            ViewBag.id_subserie = new SelectList(db.p_subserie, "id", "codigo", t_lote.id_subserie);
            return View(t_lote);
        }

        // GET: lote/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_lote t_lote = db.t_lote.Find(id);
            if (t_lote == null)
            {
                return HttpNotFound();
            }
            return View(t_lote);
        }

        // POST: lote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var buscaPDF = db.t_carpeta.Where(f => f.id_lote == id && f.estado != "D");
            var conProceso = buscaPDF.Count();
            t_lote t_lote = db.t_lote.Find(id);
            if (conProceso == 0)
            {
                var Sql = "DELETE FROM t_carpeta WHERE id_lote = " + id;
                db.Database.ExecuteSqlCommand(Sql);

                db.t_lote.Remove(t_lote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("errorBorrar", "No puede Eliminar ya que tiene Indexación!");
            return View(t_lote);
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