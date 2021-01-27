using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;
using InventoryManagement.Services;
using InventoryManagement.ViewModel;
using InventoryManagement.Mapping;

namespace InventoryManagement.Controllers
{
    public class ProcessController : Controller
    {
        private InventoryModelContainer db = new InventoryModelContainer();

        // GET: Process
        public ActionResult Index([Bind(Include = "Id,StockItem,Sellin,Quality")] Inventory inventory)
        {

                ViewBag.Message = "Next day process";
                var inventories = db.Inventories;

                var _InventoryViewModel = new InventoryViewModel()
                {
                    InventoriesList = inventories.ToList()
                };

                NextDay nextDay = new NextDay();

            foreach (Inventory inv in inventories.OrderBy(i => i.StockItem))
                {
                    nextDay.UpdateInventory(inv.Id);

                using (var context = new InventoryModelContainer())
                {
                    var std = context.Inventories.Where(i => i.Id == inv.Id).FirstOrDefault<Inventory>();
                 
                    std.StockItem = nextDay.stockItem;
                    std.Sellin = nextDay.sellin;
                    std.Quality = nextDay.quality;

                    context.SaveChanges();
                    
                }

            }

            return RedirectToAction("Index", "Inventories");

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
