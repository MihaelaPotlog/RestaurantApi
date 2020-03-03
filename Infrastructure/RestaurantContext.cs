using System.Collections.Generic;
using Domain;
using Infrastructure.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;


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
            modelBuilder.Entity<IngredientOnStock>().HasData(
                IngredientOnStock.Create("Turmeric", 24.7),
                IngredientOnStock.Create("Salt", 100.0),
                IngredientOnStock.Create("Chicken meat", 5000.0),
                IngredientOnStock.Create("Eggs", 400.0),
                IngredientOnStock.Create("Milk", 300.0),
                IngredientOnStock.Create("Cheese", 200.0),
                IngredientOnStock.Create("Red Beans", 389.0),
                IngredientOnStock.Create("White Beans", 367.0),
                IngredientOnStock.Create("Tomatoes", 178.5),
                IngredientOnStock.Create("Broccoli", 98.5),
                IngredientOnStock.Create("Soy Sauce", 100.0),
                IngredientOnStock.Create("Cornstarch", 10.0),
                IngredientOnStock.Create("Ginger", 20.0),
                IngredientOnStock.Create("Onions", 147.7)
            );
           
          
            modelBuilder.Entity<Dish>().HasData(
                Dish.Create("Chinese Pepper Steak",37.5, true),
                Dish.Create("Chicken Pasta", 21.0, false)

            );
           
        }
    }
}
