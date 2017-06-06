using OnlinePizzaWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Repository
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizzas> Pizzas { get; }
        IEnumerable<Pizzas> PizzasOfTheWeek { get; }

        Pizzas GetPizzaById(int? id);
        Task<Pizzas> GetPizzaByIdAsync(int? id);

        bool PizzaExists(int id);

        IEnumerable<Pizzas> GetPizzasByName(string name);

        IEnumerable<Pizzas> GetAll();
        Task<IEnumerable<Pizzas>> GetAllAsync();

        void Add(Pizzas pizza);
        void Update(Pizzas pizza);
        void Remove(Pizzas pizza);

        Task SaveChangesAsync();

        void ClearDatabase();
        void SeedDatabase();

    }
}
