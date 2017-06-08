using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlinePizzaWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace OnlinePizzaWebApplication.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(AppDbContext context, IServiceProvider serviceProvider)
        {
            context.Database.EnsureCreated();

            if (context.Pizzas.Any())
            {
                return;
            }

            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var _userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var cat1 = new Categories { Name = "Standard", Description = "The Bakery's Standard pizzas all year around." };
            var cat2 = new Categories { Name = "Spcialities", Description = "The Bakery's Speciality pizzas only for a limited time." };
            var cat3 = new Categories { Name = "News", Description = "The Bakery's New pizzas on the menu." };

            var cats = new List<Categories>()
            {
                cat1, cat2, cat3
            };
            
            var piz1 = new Pizzas { Name = "Capricciosa", Price = 70.00M, Category = cat1, Description = "A normal pizza with a taste from the forest.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2a/Pizza_capricciosa.jpg", IsPizzaOfTheWeek = false };
            var piz2 = new Pizzas { Name = "Veggie", Price = 70.00M, Category = cat3, Description = "Veggie Pizza for vegitarians", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3f/Vegetarian_pizza.jpg", IsPizzaOfTheWeek = false };
            var piz3 = new Pizzas { Name = "Hawaii", Price = 75.00M, Category = cat1, Description = "A nice tasting pizza from Hawaii.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d1/Hawaiian_pizza_1.jpg", IsPizzaOfTheWeek = true };
            var piz4 = new Pizzas { Name = "Margarita", Price = 65.00M, Category = cat1, Description = "A basic pizza for everyone.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg", IsPizzaOfTheWeek = false };
            var piz5 = new Pizzas { Name = "Kebab Special", Price = 85.00M, Category = cat2, Description = "A special pizza with kebab for the hungry one.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7c/Pizza_bella_vista.jpg", IsPizzaOfTheWeek = true };

            var pizs = new List<Pizzas>()
            {
                piz1, piz2, piz3, piz4, piz5
            };

            var user1 = new IdentityUser { UserName = "user1@gmail.com", Email = "user1@gmail.com" };
            var user2 = new IdentityUser { UserName = "user2@gmail.com", Email = "user2@gmail.com" };
            var user3 = new IdentityUser { UserName = "user3@gmail.com", Email = "user3@gmail.com" };
            var user4 = new IdentityUser { UserName = "user4@gmail.com", Email = "user4@gmail.com" };
            var user5 = new IdentityUser { UserName = "user5@gmail.com", Email = "user5@gmail.com" };

            string userPassword = "Password123";

            var users = new List<IdentityUser>()
            {
                user1, user2, user3, user4, user5
            };

            foreach (var user in users)
            {
                await _userManager.CreateAsync(user, userPassword);
            }

            var revs = new List<Reviews>()
            {
                new Reviews { User = user1, Title ="Best Pizza with mushrooms", Description="I love this Pizza with mushrooms on it.", Grade=4, Date=DateTime.Now, Pizza = piz1 },
                new Reviews { User = user2, Title ="Worst Pizza with mushrooms", Description="I hate this Pizza with mushrooms on it.", Grade=1, Date=DateTime.Now.AddDays(-1), Pizza = piz1 },
                new Reviews { User = user2, Title ="Only Bland Vegetables", Description="Tasteless vegetables on this soggy Pizza.", Grade=1, Date=DateTime.Now, Pizza = piz2 },
                new Reviews { User = user3, Title ="Great Veggie Pizza", Description="Good choice if you are a vegitarian.", Grade=5, Date=DateTime.Now.AddDays(-6), Pizza = piz2 },
                new Reviews { User = user4, Title ="Amazing pineapples", Description="I love the taste of the pineapples on this pizza.", Grade=4, Date=DateTime.Now.AddDays(-4), Pizza = piz3 },
                new Reviews { User = user1, Title ="Too simple", Description="Too simple pizza, for such a high price.", Grade=2, Date=DateTime.Now.AddDays(-2), Pizza = piz4 },
                new Reviews { User = user5, Title ="Super Special", Description="Super special pizza, the best taste in the world!", Grade=5, Date=DateTime.Now.AddDays(-9), Pizza = piz5 },
            };

            var ing1 = new Ingredients { Name = "Cheese" };
            var ing2 = new Ingredients { Name = "Flour" };
            var ing3 = new Ingredients { Name = "Tomatoe sauce" };
            var ing4 = new Ingredients { Name = "Lettuce" };
            var ing5 = new Ingredients { Name = "Mushrooms" };
            var ing6 = new Ingredients { Name = "Kebab" };
            var ing7 = new Ingredients { Name = "Shrimp" };
            var ing8 = new Ingredients { Name = "Pineapple" };
            var ing9 = new Ingredients { Name = "Ham" };
            var ing10 = new Ingredients { Name = "Broccoli" };
            var ing11 = new Ingredients { Name = "Onions" };

            var ings = new List<Ingredients>()
            {
                ing1, ing2, ing3, ing4, ing5, ing6, ing7, ing8, ing9, ing10, ing11
            };

            var pizIngs = new List<PizzaIngredients>()
            {
                new PizzaIngredients { Ingredient = ing1, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing5, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing9, Pizza = piz1 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing4, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing10, Pizza = piz2 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz3 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz3 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz3 },
                new PizzaIngredients { Ingredient = ing8, Pizza = piz3 },
                new PizzaIngredients { Ingredient = ing9, Pizza = piz3 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz4 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz4 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz4 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing6, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing4, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing11, Pizza = piz5 },

            };

            context.Categories.AddRange(cats);
            context.Pizzas.AddRange(pizs);
            context.Reviews.AddRange(revs);
            context.Ingredients.AddRange(ings);
            context.PizzaIngredients.AddRange(pizIngs);
            context.SaveChanges();
        }

    }
}
