using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using Domain;
using Infrastructure.DataSeeding;
using Infrastructure.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace Infrastructure
{
    sealed public class RestaurantContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<IngredientOnStock> Stock { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<IngredientSupplier> SupplierIngredients { get; set; }

        public RestaurantContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=Restaurant;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DishIngredientConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierIngredientConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDishConfiguration());
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());

            Seed(modelBuilder);



        }

        private void Seed(ModelBuilder modelBuilder)
        {

            var seedingDataJson = File.ReadAllText("C:\\Users\\mihaela\\source\\repos\\Restaurant\\Infrastructure\\DataSeeding\\Data.json");
            var des = JsonConvert.DeserializeObject<Data>(seedingDataJson);

            List<IngredientOnStock> seededIngredients = new List<IngredientOnStock>();
            foreach (var ingredient in des.IngredientsOnStock)
            {
                seededIngredients.Add(IngredientOnStock.Create(ingredient.Key, ingredient.Value));
            }

            modelBuilder.Entity<IngredientOnStock>().HasData(seededIngredients);

            // List<Dish> seededDishes = new List<Dish>();
            // foreach (var dish in des.Dishes)
            // {
            //     foreach (var usedIngredient in dish.UsedIngredients)
            //     {
            //         var usedIngredientOnStock = seededIngredients.Find(ingredient => ingredient.Name == usedIngredient.Key);
            //         DishIngredient dishIngredientLink = new DishIngredient() {Ingredient = usedIngredientOnStock, Dish = dish};
            //     }
            //     
            //     seededDishes.Add(Dish.Create(dish.Name,dish.Price, true, ));
            // }
            
        }

    }
}
