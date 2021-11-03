using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NutrientsProject.Source
{
    public class Database
    {
        static DatabaseContext Local()
        {
            return new DatabaseContext();
        }
        public static void DefaultData()
        {
            using var context = Local();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var carbohydrates = new Nutrient() { NutrientID = 1, Name = "Carbohydrates", Unit = "g" };
            var fats = new Nutrient() { NutrientID = 2, Name = "Fats", Unit = "g" };
            var proteins = new Nutrient() { NutrientID = 3, Name = "Protein", Unit = "g" };

            var apple = new Product() { ProductID = 1, Name = "Apple" };
            var banana = new Product() { ProductID = 2, Name = "Bannan" };

            var test1 = new ProductNutrient() { Product = apple, Nutrient = carbohydrates, Amount = 10 };
            var test2 = new ProductNutrient() { Product = banana, Nutrient = fats, Amount = 20 };
            var test3 = new ProductNutrient() { Product = banana, Nutrient = proteins, Amount = 20 };

            context.NutrientProduct.Add(test1);
            context.NutrientProduct.Add(test2);
            context.NutrientProduct.Add(test3);

            context.SaveChanges();
        }

        public static List<Product> GetAllProductsWithNutrients()
        {
            using var context = Local();


            var allProductsWithNutrients = context.Products
                .Include(np => np.ProductNutrients)
                .ThenInclude(n => n.Nutrient)
                .ToList();

            return allProductsWithNutrients;
        }

        public static IEnumerable<Nutrient> GetAllNutrients()
        {
            using var context = Local();

            var allProductsWithNutrients = context.Nutrients.ToList();

            return allProductsWithNutrients;
        }
    }
}