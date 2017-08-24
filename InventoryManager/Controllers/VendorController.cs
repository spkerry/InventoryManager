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
    public class VendorController : Controller 
    {
        private readonly ApplicationDbContext context;

        public VendorController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Vendor> vendors = context.Vendors.ToList();

            return View(vendors);
        }

        public IActionResult Add()
        {
            AddVendorViewModel addVendorViewModel = new AddVendorViewModel();
            return View(addVendorViewModel);
        }

        [HttpPost]
        public IActionResult Add (AddVendorViewModel addVendorViewModel)
        {
            if (ModelState.IsValid)
            {
                Vendor newVendor = new Vendor
                {
                    Name = addVendorViewModel.Name,
                    Contact = addVendorViewModel.Contact,
                    Email = addVendorViewModel.Email,
                    PhoneNumber = addVendorViewModel.PhoneNumber,
                    DateAdded = DateTime.Now
                };

                context.Vendors.Add(newVendor);
                context.SaveChanges();

                return Redirect("/Vendor/Index");
            }
            else
            {
                return View(addVendorViewModel);
            }
        }

        public IActionResult ItemsByVendor(int id)
        {
            if (id == 0)
            {
                return Redirect("/Index");
            }

            Vendor theVendorItems = context.Vendors
                .Include(v => v.Items)
                .Single(v => v.ID == id);

            ViewBag.Title = "Items from: " + theVendorItems.Name;
            ViewBag.name = theVendorItems.Name;
            return View(theVendorItems.Items);
        }
    }
}
