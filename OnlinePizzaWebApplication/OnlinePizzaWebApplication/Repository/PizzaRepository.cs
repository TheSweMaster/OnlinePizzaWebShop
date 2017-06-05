using Microsoft.EntityFrameworkCore;
using OnlinePizzaWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly AppDbContext _context;

        public PizzaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pizza> Pizzas => _context.Pizzas; //include here

        public IEnumerable<Pizza> PizzasOfTheWeek => _context.Pizzas.Where(p => p.IsPizzaOfTheWeek);

        public void Add(Pizza pizza)
        {
            _context.Add(pizza);
        }

        public void ClearDatabase()
        {
            var pizzas = _context.Pizzas.ToList();
            _context.RemoveRange(pizzas);
        }

        public IEnumerable<Pizza> GetAll()
        {
            return _context.Pizzas.ToList();
        }

        public async Task<IEnumerable<Pizza>> GetAllAsync()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public Pizza GetPizzaById(int? id)
        {
            return _context.Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Pizza> GetPizzaByIdAsync(int? id)
        {
            return await _context.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public IEnumerable<Pizza> GetPizzasByName(string name)
        {
            return _context.Pizzas.Where(p => p.Name == name);
        }

        public bool PizzaExists(int id)
        {
            return _context.Pizzas.Any(p => p.Id == id);
        }

        public void Remove(Pizza pizza)
        {
            _context.Remove(pizza);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SeedDatabase()
        {
            throw new NotImplementedException();
        }

        public void Update(Pizza pizza)
        {
            _context.Update(pizza);
        }
    }
}
