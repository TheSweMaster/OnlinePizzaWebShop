﻿using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Pizzas> Pizzas => _context.Pizzas.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients); //include here

        public IEnumerable<Pizzas> PizzasOfTheWeek => _context.Pizzas.Where(p => p.IsPizzaOfTheWeek).Include(p => p.Category);

        public void Add(Pizzas pizza)
        {
            _context.Add(pizza);
        }

        public void ClearDatabase()
        {
            var pizzas = _context.Pizzas.ToList();
            _context.RemoveRange(pizzas);
        }

        public IEnumerable<Pizzas> GetAll()
        {
            return _context.Pizzas.ToList();
        }

        public async Task<IEnumerable<Pizzas>> GetAllAsync()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public Pizzas GetPizzaById(int? id)
        {
            return _context.Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Pizzas> GetPizzaByIdAsync(int? id)
        {
            return await _context.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public IEnumerable<Pizzas> GetPizzasByName(string name)
        {
            return _context.Pizzas.Where(p => p.Name == name);
        }

        public bool PizzaExists(int id)
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

        public void SeedDatabase()
        {
            throw new NotImplementedException();
        }

        public void Update(Pizzas pizza)
        {
            _context.Update(pizza);
        }
    }
}
