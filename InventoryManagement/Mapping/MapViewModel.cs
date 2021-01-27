using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagement.Models;
using InventoryManagement.ViewModel;

namespace InventoryManagement.Mapping
{
    public class MapViewModel
    {
        public InventoryViewModel MapInventoryViewModel(Inventory _inventory)
        {
            InventoryViewModel inventoryViewModel = new InventoryViewModel()
            {
                Id = _inventory.Id,
                StockItem = _inventory.StockItem,
                Sellin = _inventory.Sellin.Value,
                Quality = _inventory.Quality.Value
               
            };
            return inventoryViewModel;
        }


        public Inventory MapInventoryModel(InventoryViewModel _inventoryViewModel)
        {
            Inventory inventoryModel = new Inventory
            {
                Id = _inventoryViewModel.Id,
                StockItem = _inventoryViewModel.StockItem,
                Sellin = _inventoryViewModel.Sellin,
                Quality = _inventoryViewModel.Quality
               
            };
            return inventoryModel;
        }
    }
}