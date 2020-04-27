using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobPortalApp.Models;

namespace JobPortalApp.Controllers
{
    public class PozicionPunesController : Controller
    {
        private JobPortalEntities db = new JobPortalEntities();

        // GET: PozicionPunes
        public ActionResult Index()
        {
            var pozicionPunes = db.PozicionPunes.Include(p => p.Kompania);
            return View(pozicionPunes.ToList());
        }

        // GET: PozicionPunes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PozicionPune pozicionPune = db.PozicionPunes.Find(id);
            if (pozicionPune == null)
            {
                return HttpNotFound();
            }
            return View(pozicionPune);
        }

        // GET: PozicionPunes/Create
        public ActionResult Create()
        {
            ViewBag.ID_Kompanie = new SelectList(db.Kompanias, "ID_Kompani", "Emri");
            return View();
        }

        // POST: PozicionPunes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Pozicion,Emri_Poz,Tipi,ID_Kompanie")] PozicionPune pozicionPune)
        {
            if (ModelState.IsValid)
            {
                db.PozicionPunes.Add(pozicionPune);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Kompanie = new SelectList(db.Kompanias, "ID_Kompani", "Emri", pozicionPune.ID_Kompanie);
            return View(pozicionPune);
        }

        // GET: PozicionPunes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PozicionPune pozicionPune = db.PozicionPunes.Find(id);
            if (pozicionPune == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Kompanie = new SelectList(db.Kompanias, "ID_Kompani", "Emri", pozicionPune.ID_Kompanie);
            return View(pozicionPune);
        }

        // POST: PozicionPunes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Pozicion,Emri_Poz,Tipi,ID_Kompanie")] PozicionPune pozicionPune)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pozicionPune).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Kompanie = new SelectList(db.Kompanias, "ID_Kompani", "Emri", pozicionPune.ID_Kompanie);
            return View(pozicionPune);
        }

        // GET: PozicionPunes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PozicionPune pozicionPune = db.PozicionPunes.Find(id);
            if (pozicionPune == null)
            {
                return HttpNotFound();
            }
            return View(pozicionPune);
        }

        // POST: PozicionPunes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PozicionPune pozicionPune = db.PozicionPunes.Find(id);
            db.PozicionPunes.Remove(pozicionPune);
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
