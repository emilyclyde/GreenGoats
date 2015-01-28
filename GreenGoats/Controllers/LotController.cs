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
    public class LotController : Controller
    {
        private GrazingContext db = new GrazingContext();

        // GET: Lot
        public ActionResult Index()
        {
            return View(db.Lots.ToList());
        }

        // GET: Lot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lot lot = db.Lots.Find(id);
            if (lot == null)
            {
                return HttpNotFound();
            }
            return View(lot);
        }

        // GET: Lot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LotID,GoatID,CustomerID,GoatName,CustomerFirst,CustomerLast,LotAddress,LotDescription")] Lot lot)
        {
            if (ModelState.IsValid)
            {
                db.Lots.Add(lot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lot);
        }

        // GET: Lot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lot lot = db.Lots.Find(id);
            if (lot == null)
            {
                return HttpNotFound();
            }
            return View(lot);
        }

        // POST: Lot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LotID,GoatID,CustomerID,GoatName,CustomerFirst,CustomerLast,LotAddress,LotDescription")] Lot lot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lot);
        }

        // GET: Lot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lot lot = db.Lots.Find(id);
            if (lot == null)
            {
                return HttpNotFound();
            }
            return View(lot);
        }

        // POST: Lot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lot lot = db.Lots.Find(id);
            db.Lots.Remove(lot);
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
