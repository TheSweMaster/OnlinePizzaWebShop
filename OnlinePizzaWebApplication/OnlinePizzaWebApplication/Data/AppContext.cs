using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlinePizzaWebApplication.Models;

namespace OnlinePizzaWebApplication.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Pizzas> Pizzas { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<PizzaIngredients> PizzaIngredients { get; set; }
        public DbSet<Reviews> Reviews { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //      "Server = (localdb)\\mssqllocaldb; Database = PizzaShop; Trusted_Connection = True; ");
        //}

    }
}
