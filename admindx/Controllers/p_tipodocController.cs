using admindx.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admindx.Controllers
{
    public class p_tipodocController : Controller
    {
        private gdocxEntities db = new gdocxEntities();
        // GET: p_tipodoc
        public ActionResult Index()
        {
            var tipodocs = db.p_tipodoc.ToList();
            //foreach (var tip in tipodocs)
            //{
            //    tip.items = db.p_tipoitem.Where(p => p.id_tipo == tip.id).ToList();
            //    foreach (var item in tip.items)
            //    {
            //        item.resps = db.p_tiporesp.Where(p => p.id_item == item.id).ToList();
            //    }
            //}
            return View(tipodocs);
        }

        // GET: p_tipodoc/Details/5
        public ActionResult Details(int id)
        {
            p_tipodoc p_Tipodoc = db.p_tipodoc.Find(id);
            return View(p_Tipodoc);
        }

        // GET: p_tipodoc/Create
        public ActionResult Create()
        {
            p_tipodoc p_Tipodoc = new p_tipodoc();
            p_Tipodoc.id_subseries = db.p_subserie.Select(p => p.id).ToList();
            return View(p_Tipodoc);
        }

        // POST: p_tipodoc/Create
        [HttpPost]
        public ActionResult Create(p_tipodoc p_Tipodoc)
        {
            try
            {
                // TODO: Add insert logic here
                db.p_tipodoc.Add(p_Tipodoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: p_tipodoc/Edit/5
        public ActionResult Edit(int id)
        {
            p_tipodoc p_Tipodoc = db.p_tipodoc.Find(id);
            p_Tipodoc.id_subseries = db.p_subserie.Select(p=>p.id).ToList();
            return View(p_Tipodoc);
        }

        // POST: p_tipodoc/Edit/5
        [HttpPost]
        public ActionResult Edit(p_tipodoc p_Tipodoc)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(p_Tipodoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: p_tipodoc/Delete/5
        public ActionResult Delete(int id)
        {
            p_tipodoc p_Tipodoc = db.p_tipodoc.Find(id);
            p_Tipodoc.id_subseries = db.p_subserie.Select(p => p.id).ToList();
            return View(p_Tipodoc);
        }

        // POST: p_tipodoc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                p_tipodoc p_Tipodoc = db.p_tipodoc.Find(id);
                db.p_tipodoc.Remove(p_Tipodoc);
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
