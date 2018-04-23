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

        Pizzas GetByIdIncluded(int? id);
        Task<Pizzas> GetByIdIncludedAsync(int? id);

        bool Exists(int id);

        IEnumerable<Pizzas> GetAll();
        Task<IEnumerable<Pizzas>> GetAllAsync();

        IEnumerable<Pizzas> GetAllIncluded();
        Task<IEnumerable<Pizzas>> GetAllIncludedAsync();

        void Add(Pizzas pizza);
        void Update(Pizzas pizza);
        void Remove(Pizzas pizza);

        void SaveChanges();
        Task SaveChangesAsync();

    }
}
