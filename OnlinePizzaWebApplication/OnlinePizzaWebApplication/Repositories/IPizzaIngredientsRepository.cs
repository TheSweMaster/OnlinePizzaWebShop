using OnlinePizzaWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Repositories
{
    public interface IPizzaIngredientsRepository
    {
        IEnumerable<PizzaIngredients> PizzaIngredients { get; }

        PizzaIngredients GetById(int? id);
        Task<PizzaIngredients> GetByIdAsync(int? id);

        bool Exists(int id);

        IEnumerable<PizzaIngredients> GetAll();
        Task<IEnumerable<PizzaIngredients>> GetAllAsync();

        void Add(PizzaIngredients pizzaIngredient);
        void Update(PizzaIngredients pizzaIngredient);
        void Remove(PizzaIngredients pizzaIngredient);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
