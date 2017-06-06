using OnlinePizzaWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Repositories
{
    public interface IIngredientsRepository
    {
        IEnumerable<Ingredients> Ingredients { get; }

        Ingredients GetById(int? id);
        Task<Ingredients> GetByIdAsync(int? id);

        bool Exists(int id);

        IEnumerable<Ingredients> GetAll();
        Task<IEnumerable<Ingredients>> GetAllAsync();

        void Add(Ingredients ingredient);
        void Update(Ingredients ingredient);
        void Remove(Ingredients ingredient);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
