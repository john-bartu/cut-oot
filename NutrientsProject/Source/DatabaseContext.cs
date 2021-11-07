using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace NutrientsProject.Source
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductNutrient> NutrientProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DefaultData();
        }

        private void DefaultData()
        {
            using var context = this;
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var carbohydrates = new Nutrient() { NutrientID = 1, Name = "Carbohydrates", Unit = "g" };
            var fats = new Nutrient() { NutrientID = 2, Name = "Fats", Unit = "g" };
            var proteins = new Nutrient() { NutrientID = 3, Name = "Protein", Unit = "g" };

            var apple = new Product() { ProductID = 1, Name = "Apple" };
            var banana = new Product() { ProductID = 2, Name = "Bannan" };

            var test1 = new ProductNutrient() { Product = apple, Nutrient = carbohydrates, Amount = 10 };
            var test2 = new ProductNutrient() { Product = apple, Nutrient = fats, Amount = 20 };
            var test3 = new ProductNutrient() { Product = banana, Nutrient = proteins, Amount = 20 };

            apple.ProductNutrients = new List<ProductNutrient>();
            banana.ProductNutrients = new List<ProductNutrient>();

            apple.ProductNutrients.Add(test1);
            apple.ProductNutrients.Add(test2);
            banana.ProductNutrients.Add(test3);


            this.Products.Add(apple);
            this.Products.Add(banana);
            this.SaveChanges();
        }

        public List<Product> GetAllProductsWithNutrients()
        {
            using var context = this;


            var allProductsWithNutrients = context.Products
                .Include(np => np.ProductNutrients)
                .ThenInclude(n => n.Nutrient)
                .ToList();

            return allProductsWithNutrients;
        }

        public IEnumerable<Nutrient> GetAllNutrients()
        {
            using var context = this;

            var allProductsWithNutrients = context.Nutrients.ToList();

            return allProductsWithNutrients;
        }
    }
}