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
  public class LotsController : Controller
  {
    private GrazingContext db = new GrazingContext();

    // GET: Lots
    public ActionResult Index()
    {
      return View(db.Lots.ToList());
    }

    // GET: Lots/Details/5
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

    // GET: Lots/Create
    public ActionResult Create()
    {
      var lots = new List<string>();
      var lotQuery = from d in db.Lots
                     select d.LotDescription;

      lots.AddRange(lotQuery);
      ViewBag.Lotlist = new SelectList(lots);

      return View();
    }

    // POST: Lots/Create
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

    // GET: Lots/Edit/5
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

    // POST: Lots/Edit/5
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

    // GET: Lots/Delete/5
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

    // POST: Lots/Delete/5
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
