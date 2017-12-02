using Microsoft.AspNetCore.Mvc;
using InventoryManager.Data;
using InventoryManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManager.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrderController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        //Get Controller
        public IActionResult Index()
        {
            List<Order> orders = context.Orders.ToList();
            return View(orders);
        }
    }
}
