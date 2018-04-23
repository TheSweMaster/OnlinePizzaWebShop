using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlinePizzaWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using OnlinePizzaWebApplication.Data;

namespace OnlinePizzaWebApplication.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly AppDbContext _context;

        public IngredientsRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ingredients> Ingredients => _context.Ingredients.Include(x => x.PizzaIngredients); //include here

        public void Add(Ingredients ingredient)
        {
            _context.Ingredients.Add(ingredient);
        }

        public IEnumerable<Ingredients> GetAll()
        {
            return _context.Ingredients.ToList();
        }

        public async Task<IEnumerable<Ingredients>> GetAllAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public Ingredients GetById(int? id)
        {
            return _context.Ingredients.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Ingredients> GetByIdAsync(int? id)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.Ingredients.Any(p => p.Id == id);
        }

        public void Remove(Ingredients ingredient)
        {
            _context.Ingredients.Remove(ingredient);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Ingredients ingredient)
        {
            _context.Ingredients.Update(ingredient);
        }
    }
}
