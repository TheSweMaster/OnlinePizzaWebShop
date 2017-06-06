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

            var pizzas = new Pizzas[]
            {
            new Pizzas{Name="Hawaii",  Price=75.00M, Description="A nice tasting pizza from Hawaii.", ImageUrl="Hawaii.Pizza.Picture", IsPizzaOfTheWeek=true},
            new Pizzas{Name="Capricciosa",  Price=70.00M, Description="A normal pizza with a taste from the forest.", ImageUrl="Caprichosa.Pizza.Picture", IsPizzaOfTheWeek=false},
            new Pizzas{Name="Margarita",  Price=65.00M, Description="A basic pizza for everyone.", ImageUrl="Margeretha.Pizza.Picture", IsPizzaOfTheWeek=false},
            };
            foreach (var pizza in pizzas)
            {
                context.Pizzas.Add(pizza);
            }
            context.SaveChanges();

        }

        //private void CreateDataV2()
        //{
        //    var piz1 = new Pizzas { Name = "Caprichosa", Description = "Pizza from Italy with great taste.", Prize = 70 };
        //    var piz2 = new Pizzas { Name = "Veggie", Description = "Veggie Pizza for vegitarians", Prize = 65 };

        //    var pizs = new List<Pizzas>()
        //    {
        //        piz1, piz2,
        //    };

        //    var revs = new List<Reviews>()
        //    {
        //        new Reviews { Title ="Best Pizza with mushrooms", Description="I love this Pizza with mushrooms on it.", Grade=4, Date=DateTime.Now, Pizza = piz1 },
        //        new Reviews { Title ="Worst Pizza with mushrooms", Description="I hate this Pizza with mushrooms on it.", Grade=1, Date=DateTime.Now.AddDays(-1), Pizza = piz1 },
        //        new Reviews { Title ="Only Bland Vegetables", Description="Tasteless vegetables on this soggy Pizza.", Grade=0, Date=DateTime.Now, Pizza = piz2 },
        //        new Reviews { Title ="Great Veggie Pizza", Description="Good choice if you are a vegitarian.", Grade=5, Date=DateTime.Now.AddDays(-6), Pizza = piz2 },
        //    };

        //    var orgs = new List<Orgins>()
        //    {
        //        new Orgins { City = "Rome", Country = "Italy", Date = DateTime.Now.Date.AddYears(-186), Pizza = piz1 },
        //        new Orgins { City = "Gothenburg", Country = "Sweden", Date = DateTime.Now.Date.AddYears(-6), Pizza = piz2 },
        //    };

        //    var ing1 = new Ingredients { Name = "Cheese", Gluten = 0, Type = Types.Other };
        //    var ing2 = new Ingredients { Name = "Flour", Gluten = 1, Type = Types.Other };
        //    var ing3 = new Ingredients { Name = "Tomatoe", Gluten = 0, Type = Types.Vegetable };
        //    var ing4 = new Ingredients { Name = "Lettuce", Gluten = 0, Type = Types.Vegetable };
        //    var ing5 = new Ingredients { Name = "Mushroom", Gluten = 0, Type = Types.Meat };
        //    var ing6 = new Ingredients { Name = "Kebab", Gluten = 1, Type = Types.Meat };
        //    var ing7 = new Ingredients { Name = "Shrimp", Gluten = 0, Type = Types.Meat };
        //    var ing8 = new Ingredients { Name = "Pineapple", Gluten = 0, Type = Types.Fruit };
        //    var ing9 = new Ingredients { Name = "Ham", Gluten = 0, Type = Types.Meat };
        //    var ing10 = new Ingredients { Name = "Broccoli", Gluten = 0, Type = Types.Vegetable };

        //    var ings = new List<Ingredients>()
        //    {
        //        ing1, ing2, ing3, ing4, ing5, ing6, ing7, ing8, ing9, ing10,
        //    };

        //    var pizIngs = new List<PizzaIngredients>()
        //    {
        //        new PizzaIngredients { Ingredient = ing1, Pizza = piz1 },
        //        new PizzaIngredients { Ingredient = ing2, Pizza = piz1 },
        //        new PizzaIngredients { Ingredient = ing3, Pizza = piz1 },
        //        new PizzaIngredients { Ingredient = ing5, Pizza = piz1 },
        //        new PizzaIngredients { Ingredient = ing9, Pizza = piz1 },
        //        new PizzaIngredients { Ingredient = ing1, Pizza = piz2 },
        //        new PizzaIngredients { Ingredient = ing2, Pizza = piz2 },
        //        new PizzaIngredients { Ingredient = ing3, Pizza = piz2 },
        //        new PizzaIngredients { Ingredient = ing4, Pizza = piz2 },
        //        new PizzaIngredients { Ingredient = ing10, Pizza = piz2 },
        //    };

        //    _context.Pizzas.AddRange(pizs);
        //    _context.Reviews.AddRange(revs);
        //    _context.Orgins.AddRange(orgs);
        //    _context.Ingredients.AddRange(ings);
        //    _context.PizzaIngredients.AddRange(pizIngs);
        //    _context.SaveChanges();
        //}

    }
}
