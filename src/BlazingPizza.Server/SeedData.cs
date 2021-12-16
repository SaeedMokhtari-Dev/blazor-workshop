using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace BlazingPizza.Server
{
    public static class SeedData
    {
        public static void Initialize(PizzaStoreContext db)
        {
            var toppings = GetToppings();

            var specials = GetPizzaSpecials();
            
            db.Toppings.AddRange(toppings);
            db.Specials.AddRange(specials);
            
            db.SaveChanges();
        }

        private static PizzaSpecial[] GetPizzaSpecials()
        {
            var specials = new PizzaSpecial[]
            {
                new()
                {
                    Name = "Basic Cheese Pizza",
                    Description = "It's cheesy and delicious. Why wouldn't you want one?",
                    BasePrice = 9.99m,
                    ImageUrl = "img/pizzas/cheese.jpg",
                },
                new()
                {
                    Id = 2,
                    Name = "The Baconatorizor",
                    Description = "It has EVERY kind of bacon",
                    BasePrice = 11.99m,
                    ImageUrl = "img/pizzas/bacon.jpg",
                },
                new()
                {
                    Id = 3,
                    Name = "Classic pepperoni",
                    Description = "It's the pizza you grew up with, but Blazing hot!",
                    BasePrice = 10.50m,
                    ImageUrl = "img/pizzas/pepperoni.jpg",
                },
                new()
                {
                    Id = 4,
                    Name = "Buffalo chicken",
                    Description = "Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up",
                    BasePrice = 12.75m,
                    ImageUrl = "img/pizzas/meaty.jpg",
                },
                new()
                {
                    Id = 5,
                    Name = "Mushroom Lovers",
                    Description = "It has mushrooms. Isn't that obvious?",
                    BasePrice = 11.00m,
                    ImageUrl = "img/pizzas/mushroom.jpg",
                },
                new()
                {
                    Id = 6,
                    Name = "The Brit",
                    Description = "When in London...",
                    BasePrice = 10.25m,
                    ImageUrl = "img/pizzas/brit.jpg",
                },
                new()
                {
                    Id = 7,
                    Name = "Veggie Delight",
                    Description = "It's like salad, but on a pizza",
                    BasePrice = 11.50m,
                    ImageUrl = "img/pizzas/salad.jpg",
                },
                new()
                {
                    Id = 8,
                    Name = "Margherita",
                    Description = "Traditional Italian pizza with tomatoes and basil",
                    BasePrice = 9.99m,
                    ImageUrl = "img/pizzas/margherita.jpg",
                },
            };
            return specials;
        }

        private static Topping[] GetToppings()
        {
            var toppings = new Topping[]
            {
                new()
                {
                    Name = "Extra cheese",
                    Price = 2.50m,
                },
                new()
                {
                    Name = "American bacon",
                    Price = 2.99m,
                },
                new()
                {
                    Name = "British bacon",
                    Price = 2.99m,
                },
                new()
                {
                    Name = "Canadian bacon",
                    Price = 2.99m,
                },
                new()
                {
                    Name = "Tea and crumpets",
                    Price = 5.00m
                },
                new()
                {
                    Name = "Fresh-baked scones",
                    Price = 4.50m,
                },
                new()
                {
                    Name = "Bell peppers",
                    Price = 1.00m,
                },
                new()
                {
                    Name = "Onions",
                    Price = 1.00m,
                },
                new()
                {
                    Name = "Mushrooms",
                    Price = 1.00m,
                },
                new()
                {
                    Name = "Pepperoni",
                    Price = 1.00m,
                },
                new()
                {
                    Name = "Duck sausage",
                    Price = 3.20m,
                },
                new()
                {
                    Name = "Venison meatballs",
                    Price = 2.50m,
                },
                new()
                {
                    Name = "Served on a silver platter",
                    Price = 250.99m,
                },
                new()
                {
                    Name = "Lobster on top",
                    Price = 64.50m,
                },
                new()
                {
                    Name = "Sturgeon caviar",
                    Price = 101.75m,
                },
                new()
                {
                    Name = "Artichoke hearts",
                    Price = 3.40m,
                },
                new()
                {
                    Name = "Fresh tomatoes",
                    Price = 1.50m,
                },
                new()
                {
                    Name = "Basil",
                    Price = 1.50m,
                },
                new()
                {
                    Name = "Steak (medium-rare)",
                    Price = 8.50m,
                },
                new()
                {
                    Name = "Blazing hot peppers",
                    Price = 4.20m,
                },
                new()
                {
                    Name = "Buffalo chicken",
                    Price = 5.00m,
                },
                new()
                {
                    Name = "Blue cheese",
                    Price = 2.50m,
                },
            };
            return toppings;
        }

        public static void AddAdminUser(UserManager<PizzaStoreUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminUser = new PizzaStoreUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "admin@example.com",
                EmailConfirmed = true,
                UserName = "admin@example.com"
            };
            
            var identityResult = userManager.CreateAsync(adminUser, "@dminP@ssword123").GetAwaiter().GetResult();
            if (identityResult.Errors.Any())
            {
                throw new Exception();
            }
            
            roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            
            userManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();
        }
    }
}
