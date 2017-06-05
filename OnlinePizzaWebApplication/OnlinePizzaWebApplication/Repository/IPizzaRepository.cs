using OnlinePizzaWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Repository
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> Pizzas { get; }
        IEnumerable<Pizza> PizzasOfTheWeek { get; }

        Pizza GetPizzaById(int? id);
        Task<Pizza> GetPizzaByIdAsync(int? id);

        bool PizzaExists(int id);

        IEnumerable<Pizza> GetPizzasByName(string name);

        IEnumerable<Pizza> GetAll();
        Task<IEnumerable<Pizza>> GetAllAsync();

        void Add(Pizza pizza);
        void Update(Pizza pizza);
        void Remove(Pizza pizza);

        Task SaveChangesAsync();

        void ClearDatabase();
        void SeedDatabase();

    }
}
