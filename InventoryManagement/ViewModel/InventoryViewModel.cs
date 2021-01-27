using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InventoryManagement.Models;

namespace InventoryManagement.ViewModel
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Stock Item")]
        public string StockItem { get; set; }
        [Display(Name = "Sell in number of days")]
        public int Sellin { get; set; }
        public int Quality { get; set; }


        public List<Inventory> InventoriesList { get; set; }
        public Inventory GetInventory(int id)
        {
            return InventoriesList.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Inventory> GetAllInventories()
        {
            return InventoriesList.OrderBy(i => i.StockItem);
        }

      
    }
}