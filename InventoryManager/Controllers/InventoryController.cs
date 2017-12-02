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
            IList<InventoryItem> items = context.Items.Include(i => i.Category).Include(v => v.Vendor).ToList();

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

        public IActionResult Count(int id)
        {
            if(id == 0)
            {
                IList<InventoryItem> items = context.Items.Include(i => i.Category).Include(v => v.Vendor).ToList();

                ViewBag.Name = "All items";
                return View(items);
            }
            else
            {
                InventoryCategory countCategory = context.Categories
                .Include(cat => cat.Items)
                .Single(cat => cat.ID == id);

                ViewBag.name = countCategory.Name;
                ViewBag.ID = countCategory.ID;

                return View(countCategory.Items);
            }
        }

        [HttpPost]
        public IActionResult Count(InventoryItem[] items)
        {
            foreach (InventoryItem item in items)
            {
                context.Entry(item).State = EntityState.Modified;
                item.TotalUsage += (item.Quantity - item.TempUsage);
                item.Quantity = item.TempUsage;
                item.DateModified = DateTime.Now;
            }
            context.SaveChanges();
            return Redirect("/Inventory/Index");
        }

        public IActionResult CountCategory()
        {
            List<InventoryCategory> categories = context.Categories.ToList();

            return View(categories);
        }

        public IActionResult Edit(int id)
        {
            InventoryItem editItem = context.Items.Find(id);
            EditInventoryItemViewModel editInventoryItem = new EditInventoryItemViewModel(editItem, context.Categories.ToList(), context.Vendors.ToList());
            
            
            return View(editInventoryItem);
        }

        [HttpPost]
        public IActionResult Edit(InventoryItem editItem)
        {
            if (ModelState.IsValid)
            {
                context.Entry(editItem).State = EntityState.Modified;
                context.SaveChanges();
            }

            return Redirect("/Inventory/Index");
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Items:";
            ViewBag.items = context.Items.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] itemIds)
        {
            foreach (int itemId in itemIds)
            {
                InventoryItem theItem = context.Items.Single(i => i.ID == itemId);
                context.Items.Remove(theItem);
            }

            context.SaveChanges();

            return Redirect("/Inventory/Index");
        }
    }
    
}