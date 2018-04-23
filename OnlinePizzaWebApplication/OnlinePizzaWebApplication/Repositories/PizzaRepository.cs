using Microsoft.EntityFrameworkCore;
using OnlinePizzaWebApplication.Data;
using OnlinePizzaWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly AppDbContext _context;

        public PizzaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pizzas> Pizzas => _context.Pizzas.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients); //include here

        public IEnumerable<Pizzas> PizzasOfTheWeek => _context.Pizzas.Where(p => p.IsPizzaOfTheWeek).Include(p => p.Category);

        public void Add(Pizzas pizza)
        {
            _context.Add(pizza);
        }

        public IEnumerable<Pizzas> GetAll()
        {
            return _context.Pizzas.ToList();
        }

        public async Task<IEnumerable<Pizzas>> GetAllAsync()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<IEnumerable<Pizzas>> GetAllIncludedAsync()
        {
            return await _context.Pizzas.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients).ToListAsync();
        }

        public IEnumerable<Pizzas> GetAllIncluded()
        {
            return _context.Pizzas.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients).ToList();
        }

        public Pizzas GetById(int? id)
        {
            return _context.Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Pizzas> GetByIdAsync(int? id)
        {
            return await _context.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Pizzas GetByIdIncluded(int? id)
        {
            return _context.Pizzas.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients).FirstOrDefault(p => p.Id == id);
        }

        public async Task<Pizzas> GetByIdIncludedAsync(int? id)
        {
            return await _context.Pizzas.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients).FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.Pizzas.Any(p => p.Id == id);
        }

        public void Remove(Pizzas pizza)
        {
            _context.Remove(pizza);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Pizzas pizza)
        {
            _context.Update(pizza);
        }

    }
}
