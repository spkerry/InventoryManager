using InventoryManager.Data;
using InventoryManager.Data.Migrations;
using InventoryManager.Models;
using InventoryManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoryController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<InventoryCategory> categories = context.Categories.ToList();

            return View(categories);
        }

        public IActionResult Add()
        {
            
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                InventoryCategory newCategory = new InventoryCategory
                {
                    Name = addCategoryViewModel.Name
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category/Index");
            }
            else
            {
                return View(addCategoryViewModel);
            }
        }

        public IActionResult Edit(int id)
        {
            InventoryCategory singleCategory = context.Categories.Find(id);

            return View(singleCategory);
        }

        [HttpPost]
        public IActionResult Edit(InventoryCategory editCategory)
        {
            if (ModelState.IsValid)
            {
                context.Entry(editCategory).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult ItemsByCategory(int id)
        {
            if (id == 0)
            {
                return Redirect("/Index");
            }

            InventoryCategory theCategory = context.Categories
                .Include(cat => cat.Items)
                .Single(cat => cat.ID == id);

            ViewBag.title = "Items in: " + theCategory.Name;
            ViewBag.name = theCategory.Name;
            ViewBag.ID = theCategory.ID;
            return View(theCategory.Items);
        }
    }
}
