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
    public class AplikimsController : Controller
    {
        private JobPortalEntities db = new JobPortalEntities();

        // GET: Aplikims
        public ActionResult Index()
        {
            var aplikims = db.Aplikims.Include(a => a.Kompania).Include(a => a.PozicionPune);
            return View(aplikims.ToList());
        }

        // GET: Aplikims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplikim aplikim = db.Aplikims.Find(id);
            if (aplikim == null)
            {
                return HttpNotFound();
            }
            return View(aplikim);
        }

        // GET: Aplikims/Create
        public ActionResult Create()
        {
            ViewBag.Komp_Id = new SelectList(db.Kompanias, "ID_Kompani", "Emri");
            ViewBag.Pozc_Id = new SelectList(db.PozicionPunes, "Id_Pozicion", "Emri_Poz");
            return View();
        }

        // POST: Aplikims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Aplikim,Pozc_Id,Komp_Id,Orari")] Aplikim aplikim)
        {
            if (ModelState.IsValid)
            {
                db.Aplikims.Add(aplikim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Komp_Id = new SelectList(db.Kompanias, "ID_Kompani", "Emri", aplikim.Komp_Id);
            ViewBag.Pozc_Id = new SelectList(db.PozicionPunes, "Id_Pozicion", "Emri_Poz", aplikim.Pozc_Id);
            return View(aplikim);
        }

        // GET: Aplikims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplikim aplikim = db.Aplikims.Find(id);
            if (aplikim == null)
            {
                return HttpNotFound();
            }
            ViewBag.Komp_Id = new SelectList(db.Kompanias, "ID_Kompani", "Emri", aplikim.Komp_Id);
            ViewBag.Pozc_Id = new SelectList(db.PozicionPunes, "Id_Pozicion", "Emri_Poz", aplikim.Pozc_Id);
            return View(aplikim);
        }

        // POST: Aplikims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Aplikim,Pozc_Id,Komp_Id,Orari")] Aplikim aplikim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aplikim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Komp_Id = new SelectList(db.Kompanias, "ID_Kompani", "Emri", aplikim.Komp_Id);
            ViewBag.Pozc_Id = new SelectList(db.PozicionPunes, "Id_Pozicion", "Emri_Poz", aplikim.Pozc_Id);
            return View(aplikim);
        }

        // GET: Aplikims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplikim aplikim = db.Aplikims.Find(id);
            if (aplikim == null)
            {
                return HttpNotFound();
            }
            return View(aplikim);
        }

        // POST: Aplikims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aplikim aplikim = db.Aplikims.Find(id);
            db.Aplikims.Remove(aplikim);
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
