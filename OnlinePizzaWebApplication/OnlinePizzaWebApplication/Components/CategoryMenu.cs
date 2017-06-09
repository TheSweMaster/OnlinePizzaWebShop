using Microsoft.AspNetCore.Mvc;
using OnlinePizzaWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly AppDbContext _context;
        public CategoryMenu(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _context.Categories.OrderBy(c => c.Name);
            return View(categories);
        }
    }
}
