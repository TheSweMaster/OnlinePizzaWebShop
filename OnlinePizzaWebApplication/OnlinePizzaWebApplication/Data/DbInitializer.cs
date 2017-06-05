using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlinePizzaWebApplication.Models;

namespace OnlinePizzaWebApplication.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Pizzas.Any())
            {
                return;
            }

            var pizzas = new Pizza[]
            {
            new Pizza{Name="Hawaii",  Price=75.00M, Description="A nice tasting pizza from Hawaii.", Image="Hawaii.Pizza.Picture", IsPizzaOfTheWeek=true},
            new Pizza{Name="Capricciosa",  Price=70.00M, Description="A normal pizza with a taste from the forest.", Image="Caprichosa.Pizza.Picture", IsPizzaOfTheWeek=false},
            new Pizza{Name="Margarita",  Price=65.00M, Description="A basic pizza for everyone.", Image="Margeretha.Pizza.Picture", IsPizzaOfTheWeek=false},
            };
            foreach (var pizza in pizzas)
            {
                context.Pizzas.Add(pizza);
            }
            context.SaveChanges();

        }
    }
}
