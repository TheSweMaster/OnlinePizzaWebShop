using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlinePizzaWebApplication.Repositories;
using OnlinePizzaWebApplication.Models;
using OnlinePizzaWebApplication.Data;

namespace OnlinePizzaWebApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAdminRepository _adminRepo;

        public AdminController(AppDbContext context, IAdminRepository adminRepo)
        {
            _context = context;
            _adminRepo = adminRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ClearDatabaseAsync()
        {
            await _adminRepo.ClearDatabaseAsync();
            return RedirectToAction("Index", "Pizzas", null);
        }

        public async Task<IActionResult> SeedDatabaseAsync()
        {
            await _adminRepo.ClearDatabaseAsync();
            await _adminRepo.SeedDatabaseAsync();
            return RedirectToAction("Index", "Pizzas", null);
        }

    }
}