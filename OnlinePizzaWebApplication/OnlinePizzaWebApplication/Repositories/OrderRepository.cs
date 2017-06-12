using OnlinePizzaWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(AppDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public async Task CreateOrderAsync(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _context.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    PizzaId = shoppingCartItem.Pizza.Id,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Pizza.Price
                };

                _context.OrderDetails.Add(orderDetail);
            }

            await _context.SaveChangesAsync();
        }
    }
}
