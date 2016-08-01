using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Comp2007_Project2.Models;

namespace Comp2007_Project2.Controllers
{
    public class MenuController : Controller
    {
        private MenuEntities db = new MenuEntities();


        // GET: Menu
        public ActionResult Index()
        {
            List<Item> items = db.Items.ToList();
            return View(items);
        }

        // GET: Menu/Details/5
        public ActionResult Details(int? id = 0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            ViewBag.ItemLabelId = new SelectList(db.ItemLabels, "ItemLabelId", "Name");
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "ItemTypeId", "Name");
            return View();
        }

        // POST: Menu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,ItemTypeId,ItemLabelId,Name,Price,ImageUrl,ShortDescription,LongDescription")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemLabelId = new SelectList(db.ItemLabels, "ItemLabelId", "Name", item.ItemLabelId);
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "ItemTypeId", "Name", item.ItemTypeId);
            return View(item);
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemLabelId = new SelectList(db.ItemLabels, "ItemLabelId", "Name", item.ItemLabelId);
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "ItemTypeId", "Name", item.ItemTypeId);
            return View(item);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,ItemTypeId,ItemLabelId,Name,Price,ImageUrl,ShortDescription,LongDescription")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemLabelId = new SelectList(db.ItemLabels, "ItemLabelId", "Name", item.ItemLabelId);
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "ItemTypeId", "Name", item.ItemTypeId);
            return View(item);
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
