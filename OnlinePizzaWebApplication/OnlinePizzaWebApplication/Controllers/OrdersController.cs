using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlinePizzaWebApplication.Repositories;
using OnlinePizzaWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace OnlinePizzaWebApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly AppDbContext _context;

        public OrdersController(IOrderRepository orderRepository, 
            ShoppingCart shoppingCart, AppDbContext context)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _context = context;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            var items = await _shoppingCart.GetShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pizzas first");
            }

            if (ModelState.IsValid)
            {
                await _orderRepository.CreateOrderAsync(order);
                await _shoppingCart.ClearCartAsync();

                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        [Authorize]
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = $"Thanks for your order, We'll deliver your pizzas soon!";
            return View();
        }




        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.ToListAsync();

            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var order = await _context.Orders.Include(o => o.OrderLines)
                .SingleOrDefaultAsync(m => m.OrderId == id);

            var orderDetailsList = _context.OrderDetails.Include(o => o.Pizza).Include(o => o.Order)
                .Where(x => x.OrderId == order.OrderId);

            ViewBag.OrderDetailsList = orderDetailsList;
            ViewBag.TotalPrice = orderDetailsList.Sum(x => x.Price * x.Amount);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}