using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;
using InventoryManagement.Mapping;
using InventoryManagement.ViewModel;


namespace InventoryManagement.Controllers
{
    public class InventoriesController : Controller
    {
        private InventoryModelContainer db = new InventoryModelContainer();

        // GET: Inventories
        public ActionResult Index()
        {
            ViewBag.Message = "Inventory List.";
            var inventories = db.Inventories;

            var _InventoryViewModel = new InventoryViewModel()
            {
                InventoriesList = inventories.ToList()
            };

            return View(_InventoryViewModel);
           
        }

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Message = "Details of Item.";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }

            MapViewModel mapViewModel = new MapViewModel();
            InventoryViewModel inventoryViewModel = mapViewModel.MapInventoryViewModel(inventory);

            return View(inventoryViewModel);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StockItem,Sellin,Quality")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Message = "Edit item here.";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }

            MapViewModel mapViewModel = new MapViewModel();
            InventoryViewModel inventoryViewModel = mapViewModel.MapInventoryViewModel(inventory);

            return View(inventoryViewModel);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StockItem,Sellin,Quality")] Inventory inventory)
        {
            ViewBag.Message = "Are you sure you want to delete this?";
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            MapViewModel mapViewModel = new MapViewModel();
            InventoryViewModel inventoryViewModel = mapViewModel.MapInventoryViewModel(inventory);

            return View(inventoryViewModel);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
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
