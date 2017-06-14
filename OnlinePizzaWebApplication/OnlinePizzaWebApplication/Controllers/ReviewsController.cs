using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlinePizzaWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OnlinePizzaWebApplication.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReviewsController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminIndex()
        {
            var reviews = await _context.Reviews.Include(r => r.Pizza).Include(r => r.User).ToListAsync();
            return View(reviews);
        }

        // GET: Reviews
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (isAdmin)
            {
                var allReviews = _context.Reviews.Include(r => r.Pizza).Include(r => r.User).ToList();
                return View(allReviews);
            }
            else
            {
                var reviews = _context.Reviews.Include(r => r.Pizza).Include(r => r.User)
                    .Where(r => r.User == user).ToList();
                return View(reviews);
            }
        }

        // GET: Reviews
        [AllowAnonymous]
        public async Task<IActionResult> ListAll()
        {
            var reviews = await _context.Reviews.Include(r => r.Pizza).Include(r => r.User).ToListAsync();
            return View(reviews);
        }

        // GET: Reviews
        [AllowAnonymous]
        public async Task<IActionResult> PizzaReviews(int? pizzaId)
        {
            if (pizzaId == null)
            {
                return NotFound();
            }
            var pizza = _context.Pizzas.FirstOrDefault(x => x.Id == pizzaId);
            if (pizza == null)
            {
                return NotFound();
            }
            var reviews = await _context.Reviews.Include(r => r.Pizza).Include(r => r.User).Where(x => x.Pizza.Id == pizza.Id).ToListAsync();
            if (reviews == null)
            {
                return NotFound();
            }
            ViewBag.PizzaName = pizza.Name;
            ViewBag.PizzaId = pizza.Id;

            return View(reviews);
        }

        // GET: Reviews/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Pizza)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // GET: Reviews/Create
        public IActionResult CreateWithPizza(int? pizzaId)
        {
            var review = new Reviews();

            if (pizzaId == null)
            {
                return NotFound();
            }

            var pizza = _context.Pizzas.FirstOrDefault(p => p.Id == pizzaId);
            
            if (pizza == null)
            {
                return NotFound();
            }

            review.Pizza = pizza;
            review.PizzaId = pizza.Id;
            ViewData["PizzaId"] = new SelectList(_context.Pizzas.Where(p => p.Id == pizzaId), "Id", "Name");

            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWithPizza(int pizzaId, Reviews reviews)
        {
            if (pizzaId != reviews.PizzaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                reviews.UserId = userId;
                reviews.Date = DateTime.Now;

                _context.Add(reviews);
                await _context.SaveChangesAsync();
                return Redirect($"PizzaReviews?pizzaId={pizzaId}");
            }
            ViewData["PizzaId"] = new SelectList(_context.Pizzas.Where(p => p.Id == pizzaId), "Id", "Name", reviews.PizzaId);
            return View(reviews);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Name");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Grade,PizzaId")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                reviews.UserId = userId;

                reviews.Date = DateTime.Now;
                _context.Add(reviews);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Name", reviews.PizzaId);
            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userRoles = await _userManager.GetRolesAsync(user);
            bool isAdmin = userRoles.Any(r => r == "Admin");

            if (reviews == null)
            {
                return NotFound();
            }

            if (isAdmin == false)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                if (reviews.UserId != userId)
                {
                    return BadRequest("You do not have permissions to edit this review.");
                }
            }

            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Name", reviews.PizzaId);
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Grade,Date,PizzaId")] Reviews reviews)
        {
            if (id != reviews.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                try
                {
                    if (reviews.Date == null)
                    {
                        reviews.Date = DateTime.Now;
                    }
                    reviews.UserId = userId;

                    _context.Update(reviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewsExists(reviews.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Name", reviews.PizzaId);
            return View(reviews);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Pizza)
                .SingleOrDefaultAsync(m => m.Id == id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userRoles = await _userManager.GetRolesAsync(user);
            bool isAdmin = userRoles.Any(r => r == "Admin");

            if (reviews == null)
            {
                return NotFound();
            }

            if (isAdmin == false)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                if (reviews.UserId != userId)
                {
                    return BadRequest("You do not have permissions to edit this review.");
                }
            }

            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviews = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
