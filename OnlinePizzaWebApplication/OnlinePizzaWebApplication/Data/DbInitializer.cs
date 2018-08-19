using System;
using System.Collections.Generic;
using System.Linq;
using OnlinePizzaWebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace OnlinePizzaWebApplication.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context, IServiceProvider service)
        {
            context.Database.EnsureCreated();

            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = service.GetRequiredService<UserManager<IdentityUser>>();

            if (context.Pizzas.Any())
            {
                return;
            }

            ClearDatabase(context);
            CreateAdminRole(context, roleManager, userManager);
            SeedDatabase(context, roleManager, userManager);
        }

        private static void CreateAdminRole(AppDbContext context, RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager)
        {
            bool roleExists = _roleManager.RoleExistsAsync("Admin").Result;
            if (roleExists)
            {
                return;
            }
            
            var role = new IdentityRole()
            {
                Name = "Admin"
            };
            _roleManager.CreateAsync(role).Wait();

            var user = new IdentityUser()
            {
                UserName = "admin",
                Email = "admin@default.com"
            };

            string adminPassword = "Password123";
            var userResult =  _userManager.CreateAsync(user, adminPassword).Result;

            if (userResult.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }

        private static void SeedDatabase(AppDbContext _context, RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager)
        {
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
            var piz5 = new Pizzas { Name = "Kebab Special", Price = 85.00M, Category = cat2, Description = "A special pizza with kebab for the hungry one.", ImageUrl = "http://2.bp.blogspot.com/_3cSn3Qz_4IA/THkYqKwGw1I/AAAAAAAAAPg/ybKpvRbjDWE/s1600/matsl%C3%A4kten+002.JPG", IsPizzaOfTheWeek = true };
            var piz6 = new Pizzas { Name = "Pescatore", Price = 80.00M, Category = cat1, Description = "A pizza with taste from the ocean.", ImageUrl = "https://isinginthekitchen.files.wordpress.com/2014/07/dsc_0231.jpg", IsPizzaOfTheWeek = true };
            var piz7 = new Pizzas { Name = "Barcelona", Price = 70.00M, Category = cat1, Description = "A pizza with taste from Spain, Barcelona", ImageUrl = "http://barcelona-home.com/blog/wp-content/upload/pizza/Pizzeria%20Los%20Amigos/pizza-jamon-dulce-y-champinone.jpg", IsPizzaOfTheWeek = false };
            var piz8 = new Pizzas { Name = "Flying Jacob", Price = 89.00M, Category = cat2, Description = "Flying pizza from the sky, with taste of banana.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/64/Pizza_Hawaii_Special_p%C3%A5_Pizzeria_Papillon_i_Sala_1343.jpg", IsPizzaOfTheWeek = false };
            var piz9 = new Pizzas { Name = "Kentucky", Price = 69.00M, Category = cat3, Description = "A pizza from America with the taste of Kuntucky Chicken.", ImageUrl = "http://assets.kraftfoods.com/recipe_images/opendeploy/54150_640x428.jpg", IsPizzaOfTheWeek = false };
            var piz10 = new Pizzas { Name = "La Carne", Price = 75.00M, Category = cat1, Description = "Italian pizza with lot's of delicious meat.", ImageUrl = "https://www.davannis.com/wp-content/uploads/2015/03/five-meat.jpg", IsPizzaOfTheWeek = false };

            var pizs = new List<Pizzas>()
            {
                piz1, piz2, piz3, piz4, piz5, piz6, piz7, piz8, piz9, piz10
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
                _userManager.CreateAsync(user, userPassword).Wait();
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
            var ing12 = new Ingredients { Name = "Olives" };
            var ing13 = new Ingredients { Name = "Bananas" };
            var ing14 = new Ingredients { Name = "Chicken" };
            var ing15 = new Ingredients { Name = "Tomatoes" };
            var ing16 = new Ingredients { Name = "Minced Meat" };

            var ings = new List<Ingredients>()
            {
                ing1, ing2, ing3, ing4, ing5, ing6, ing7, ing8, ing9, ing10, ing11, ing12, ing13, ing14, ing15, ing16
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

                new PizzaIngredients { Ingredient = ing1, Pizza = piz6 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz6 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz6 },
                new PizzaIngredients { Ingredient = ing4, Pizza = piz6 },
                new PizzaIngredients { Ingredient = ing7, Pizza = piz6 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing5, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing11, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing12, Pizza = piz7 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing5, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing8, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing13, Pizza = piz8 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz9 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz9 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz9 },
                new PizzaIngredients { Ingredient = ing14, Pizza = piz9 },
                new PizzaIngredients { Ingredient = ing15, Pizza = piz9 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz10 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz10 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz10 },
                new PizzaIngredients { Ingredient = ing9, Pizza = piz10 },
                new PizzaIngredients { Ingredient = ing16, Pizza = piz10 },

            };

            var ord1 = new Order
            {
                FirstName = "Pelle",
                LastName = "Andersson",
                AddressLine1 = "MainStreet 12",
                City = "Gothenburg",
                Country = "Sweden",
                Email = "pelle22@gmail.com",
                OrderPlaced = DateTime.Now.AddDays(-2),
                PhoneNumber = "0705123456",
                User = user1,
                ZipCode = "43210",
                OrderTotal = 370.00M,
            };

            var ord2 = new Order { };
            var ord3 = new Order { };

            var orderLines = new List<OrderDetail>()
            {
                new OrderDetail { Order=ord1, Pizza=piz1, Amount=2, Price=piz1.Price},
                new OrderDetail { Order=ord1, Pizza=piz3, Amount=1, Price=piz3.Price},
                new OrderDetail { Order=ord1, Pizza=piz5, Amount=3, Price=piz5.Price},
            };

            var orders = new List<Order>()
            {
                ord1
            };

            _context.Categories.AddRange(cats);
            _context.Pizzas.AddRange(pizs);
            _context.Reviews.AddRange(revs);
            _context.Orders.AddRange(orders);
            _context.OrderDetails.AddRange(orderLines);
            _context.Ingredients.AddRange(ings);
            _context.PizzaIngredients.AddRange(pizIngs);

            _context.SaveChanges();
        }

        private static void ClearDatabase(AppDbContext _context)
        {
            var pizzaIngredients = _context.PizzaIngredients.ToList();
            _context.PizzaIngredients.RemoveRange(pizzaIngredients);

            var ingredients = _context.Ingredients.ToList();
            _context.Ingredients.RemoveRange(ingredients);

            var reviews = _context.Reviews.ToList();
            _context.Reviews.RemoveRange(reviews);

            var shoppingCartItems = _context.ShoppingCartItems.ToList();
            _context.ShoppingCartItems.RemoveRange(shoppingCartItems);

            var users = _context.Users.ToList();
            var userRoles = _context.UserRoles.ToList();

            foreach (var user in users)
            {
                if (!userRoles.Any(r => r.UserId == user.Id))
                {
                    _context.Users.Remove(user);
                }
            }

            var orderDetails = _context.OrderDetails.ToList();
            _context.OrderDetails.RemoveRange(orderDetails);

            var orders = _context.Orders.ToList();
            _context.Orders.RemoveRange(orders);

            var pizzas = _context.Pizzas.ToList();
            _context.Pizzas.RemoveRange(pizzas);

            var categories = _context.Categories.ToList();
            _context.Categories.RemoveRange(categories);

            _context.SaveChanges();
        }
    }
}
