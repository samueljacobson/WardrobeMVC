using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeMVC.Models;

namespace WardrobeMVC.Controllers
{
    public class Accessories2Controller : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: Accessories2
        public ActionResult Index()
        {
            var accessories2 = db.Accessories2.Include(a => a.Occassion).Include(a => a.Season);
            return View(accessories2.ToList());
        }

        // GET: Accessories2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories2 accessories2 = db.Accessories2.Find(id);
            if (accessories2 == null)
            {
                return HttpNotFound();
            }
            return View(accessories2);
        }

        // GET: Accessories2/Create
        public ActionResult Create()
        {
            ViewBag.OccassionID = new SelectList(db.Occassions, "OccassionID", "OccassionName");
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "SeasonName");
            return View();
        }

        // POST: Accessories2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessoryID,Name,Photo,Type,Color,SeasonID,OccassionID")] Accessories2 accessories2)
        {
            if (ModelState.IsValid)
            {
                db.Accessories2.Add(accessories2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OccassionID = new SelectList(db.Occassions, "OccassionID", "OccassionName", accessories2.OccassionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "SeasonName", accessories2.SeasonID);
            return View(accessories2);
        }

        // GET: Accessories2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories2 accessories2 = db.Accessories2.Find(id);
            if (accessories2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.OccassionID = new SelectList(db.Occassions, "OccassionID", "OccassionName", accessories2.OccassionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "SeasonName", accessories2.SeasonID);
            return View(accessories2);
        }

        // POST: Accessories2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessoryID,Name,Photo,Type,Color,SeasonID,OccassionID")] Accessories2 accessories2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessories2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OccassionID = new SelectList(db.Occassions, "OccassionID", "OccassionName", accessories2.OccassionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "SeasonName", accessories2.SeasonID);
            return View(accessories2);
        }

        // GET: Accessories2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories2 accessories2 = db.Accessories2.Find(id);
            if (accessories2 == null)
            {
                return HttpNotFound();
            }
            return View(accessories2);
        }

        // POST: Accessories2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessories2 accessories2 = db.Accessories2.Find(id);
            db.Accessories2.Remove(accessories2);
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
