using Microsoft.AspNetCore.Mvc;
using OnlinePizzaWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Components
{
    public class CarouselMenu : ViewComponent
    {
        private readonly AppDbContext _context;
        public CarouselMenu(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var pizzas = _context.Pizzas.Where(x => x.IsPizzaOfTheWeek).ToList();
            return View(pizzas);
        }
    }
}
