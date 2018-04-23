using Microsoft.EntityFrameworkCore;
using OnlinePizzaWebApplication.Data;
using OnlinePizzaWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Repositories
{
    public class PizzaIngredientsRepository : IPizzaIngredientsRepository
    {
        private readonly AppDbContext _context;

        public PizzaIngredientsRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PizzaIngredients> PizzaIngredients => _context.PizzaIngredients.Include(x => x.Pizza).Include(x => x.Ingredient); //include here

        public void Add(PizzaIngredients pizzaIngredient)
        {
            _context.PizzaIngredients.Add(pizzaIngredient);
        }

        public IEnumerable<PizzaIngredients> GetAll()
        {
            return _context.PizzaIngredients.ToList();
        }

        public async Task<IEnumerable<PizzaIngredients>> GetAllAsync()
        {
            return await _context.PizzaIngredients.ToListAsync();
        }

        public PizzaIngredients GetById(int? id)
        {
            return _context.PizzaIngredients.FirstOrDefault(p => p.Id == id);
        }

        public async Task<PizzaIngredients> GetByIdAsync(int? id)
        {
            return await _context.PizzaIngredients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.PizzaIngredients.Any(p => p.Id == id);
        }

        public void Remove(PizzaIngredients pizzaIngredient)
        {
            _context.PizzaIngredients.Remove(pizzaIngredient);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(PizzaIngredients pizzaIngredient)
        {
            _context.PizzaIngredients.Update(pizzaIngredient);
        }
    }
}
