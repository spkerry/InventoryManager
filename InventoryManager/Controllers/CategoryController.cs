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
    }
}
