using InventoryManager.Data;
using InventoryManager.Models;
using Microsoft.AspNetCore.Mvc;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Controllers
{
    public class InventoryController : Controller
    {
        private ApplicationDbContext context;

        public InventoryController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        public IActionResult Index()
        {
            IList<InventoryItem> items = context.Items.Include(i => i.Category).ToList();

            return View(items);
        }

        public IActionResult Add()
        {
            AddInventoryItemViewModel addInventoryItem = new AddInventoryItemViewModel(context.Categories.ToList(), context.Vendors.ToList());

            return View(addInventoryItem);
        }

        [HttpPost]
        public IActionResult Add(AddInventoryItemViewModel addInventoryItemViewModel)
        {
            if (ModelState.IsValid)
            {
                InventoryCategory newInventoryCategory = context.Categories.Single(c => c.ID == addInventoryItemViewModel.CategoryID);
                Vendor newVendor = context.Vendors.Single(v => v.ID == addInventoryItemViewModel.VendorID);

                InventoryItem newItem = new InventoryItem
                {
                    Name = addInventoryItemViewModel.Name,
                    Upc = addInventoryItemViewModel.Upc,
                    Cost = addInventoryItemViewModel.Cost,
                    Quantity = addInventoryItemViewModel.Quantity,
                    Unit = addInventoryItemViewModel.Unit,
                    DateAdded = DateTime.Now,
                    Category = newInventoryCategory,
                    Vendor = newVendor
                };

                context.Items.Add(newItem);
                context.SaveChanges();

                return Redirect("/Inventory/Index");
            }
            else
            {
                AddInventoryItemViewModel addInventoryItemViewModel1 = new AddInventoryItemViewModel(context.Categories.ToList(), context.Vendors.ToList());
                return View(addInventoryItemViewModel1);
            }
        }
    }
    
}