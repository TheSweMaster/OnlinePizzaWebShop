using OnlinePizzaWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Repositories

{
    public interface IPizzaRepository
    {
        IEnumerable<Pizzas> Pizzas { get; }
        IEnumerable<Pizzas> PizzasOfTheWeek { get; }

        Pizzas GetById(int? id);
        Task<Pizzas> GetByIdAsync(int? id);

        bool Exists(int id);

        IEnumerable<Pizzas> GetAll();
        Task<IEnumerable<Pizzas>> GetAllAsync();

        void Add(Pizzas pizza);
        void Update(Pizzas pizza);
        void Remove(Pizzas pizza);

        void SaveChanges();
        Task SaveChangesAsync();

        void ClearDatabase();
        //void SeedDatabase();

    }
}
