using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreenGoats.DAL;
using GreenGoats.Models;

namespace GreenGoats.Controllers
{
    public class GoatController : Controller
    {
        private GrazingContext db = new GrazingContext();

        // GET: Goat
        public ActionResult Index()
        {
            return View(db.Goats.ToList());
        }

        // GET: Goat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goat goat = db.Goats.Find(id);
            if (goat == null)
            {
                return HttpNotFound();
            }
            return View(goat);
        }

        // GET: Goat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoatID,GoatName,GoatColor,GoatType,GoatGender")] Goat goat)
        {
            if (ModelState.IsValid)
            {
                db.Goats.Add(goat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goat);
        }

        // GET: Goat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goat goat = db.Goats.Find(id);
            if (goat == null)
            {
                return HttpNotFound();
            }
            return View(goat);
        }

        // POST: Goat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoatID,GoatName,GoatColor,GoatType,GoatGender")] Goat goat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goat);
        }

        // GET: Goat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goat goat = db.Goats.Find(id);
            if (goat == null)
            {
                return HttpNotFound();
            }
            return View(goat);
        }

        // POST: Goat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Goat goat = db.Goats.Find(id);
            db.Goats.Remove(goat);
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
