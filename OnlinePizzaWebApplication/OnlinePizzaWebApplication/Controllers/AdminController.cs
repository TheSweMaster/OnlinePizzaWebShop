using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlinePizzaWebApplication.Repositories;
using OnlinePizzaWebApplication.Models;

namespace OnlinePizzaWebApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPizzaRepository _pizzaRepo;

        public AdminController(AppDbContext context, IPizzaRepository pizzaRepo)
        {
            _context = context;
            _pizzaRepo = pizzaRepo;
        }

        public IActionResult Index()
        {
            //string text = "Hello Admin";
            return View();
        }

        public IActionResult ClearDatabase()
        {
            _pizzaRepo.ClearDatabase();
            return RedirectToAction("Index", "Pizzas", null);
        }

    }
}