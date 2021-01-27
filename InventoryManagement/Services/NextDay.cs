using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagement.Models;
using InventoryManagement.ViewModel;
using InventoryManagement.Mapping;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace InventoryManagement.Services
{
    public class NextDay
    {
        public string stockItem = string.Empty;
        public int id = 0;
        public int sellin = 0;
        public int quality = 0;
        public List<Inventory> InventoriesList { get; set; }
        private InventoryModelContainer db = new InventoryModelContainer();

        public NextDay()
        {

        }

        public Inventory UpdateInventory(int id)
        {
            Inventory updatedModel = new Inventory();
            Inventory inventory = db.Inventories.Find(id);

           
                stockItem = inventory.StockItem;
                //Get sellin value
                sellin = inventory.Sellin.Value;
                //get Quality value
                quality = inventory.Quality.Value;

                //if stockitem is "Aged Brie"
                if (stockItem.ToString().ToUpper() == "AGED BRIE")
                {
                    //set sellin value decrease by 1
                    sellin = sellin - 1;
                    //set Quality value increase by 1
                    quality = quality + 1;

                    updatedModel.StockItem = this.stockItem; ;
                    updatedModel.Sellin = this.sellin;
                    updatedModel.Quality = this.quality;

                  
                }

            //if stockitem is "Frozen Item"
            if (stockItem.ToString().ToUpper() == "FROZEN ITEM")
            {
                if (sellin < 0)
                {
                    //set quality value decrease by 2
                    quality = quality - 2;
                }
                else
                {
                    //set quality value decrease by 1
                    quality = quality - 1;
                }
                
                //set sellin value decrease by 1
                sellin = sellin - 1;

                updatedModel.StockItem = this.stockItem; ;
                updatedModel.Sellin = this.sellin;
                updatedModel.Quality = this.quality;

            }

            //if stockitem is "Fresh Item"
            if (stockItem.ToString().ToUpper() == "FRESH ITEM")
            {
                if (sellin < 0)
                {
                    //set quality value decrease by 4
                    quality = quality - 4;
                }
                else
                {
                    //set quality value decrease by 2
                    quality = quality - 2;
                }

                //set sellin value decrease by 1
                sellin = sellin - 1;

                updatedModel.StockItem = this.stockItem; ;
                updatedModel.Sellin = this.sellin;
                updatedModel.Quality = this.quality;

            }


            //if stockitem is "Christmas Crackers"
            if (stockItem.ToString().ToUpper() == "CHRISTMAS CRACKERS")
            {
                if (sellin < 0)
                {
                    //set quality value to 0
                    quality = 0;
                }
                else if (sellin >=6 && sellin <= 10)
                {
                    //set quality value increase by 2
                    quality = quality + 2;
                }else if (sellin >= 0 && sellin <= 5)
                {
                    //set quality value increase by 3
                    quality = quality + 3;
                }

                //set sellin value decrease by 1
                sellin = sellin - 1;

                updatedModel.StockItem = this.stockItem; ;
                updatedModel.Sellin = this.sellin;
                updatedModel.Quality = this.quality;

            }

            //if stockitem is "INVALID ITEM"
            if (stockItem.ToString().ToUpper() == "INVALID ITEM")
            {
                //change stock item text
                stockItem = "NO SUCH ITEM";
                //set sellin value to 0
                sellin = 0;
                //set quality value to 0
                quality = 0;

            }
            //set quality range
            if (quality > 50)
            {
                quality = 50;
            }
            else if (quality < 0)
            {
                quality = 0;
            }
            return updatedModel;
        }


    }
}