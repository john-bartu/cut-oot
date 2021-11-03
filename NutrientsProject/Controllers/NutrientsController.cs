using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NutrientsProject.Source;

namespace NutrientsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NutrientsController : BasicController<NutrientsController>
    {
        public NutrientsController(ILogger<NutrientsController> logger) : base(logger)
        {
        }

        [HttpGet(Name = "GetNutrientList")]
        public IEnumerable<Product> Get()
        {

            InsertData();

            return PrintData();
        }


        private static void InsertData()
        {
            using (var context = new Database())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // Adds some books
                var cukier = new Nutrient() { NutrientID = 1, Name = "Cukier", Unit = "g" };
                var carbon = new Nutrient() { NutrientID = 2, Name = "Carbon", Unit = "g" };

                var apple = new Product() { ProductID = 1, Name = "Apple" };
                var banan = new Product() { ProductID = 2, Name = "Banan" };

                var test1 = new NutrientProduct() { Product = apple, Nutrient = cukier, Amount = 10 };
                var test2 = new NutrientProduct() { Product = banan, Nutrient = carbon, Amount = 20 };

                context.NutrientProduct.Add(test1);
                context.NutrientProduct.Add(test2);

                context.SaveChanges();
            }
        }

        private static List<Product> PrintData()
        {
            // Gets and prints all books in database
            using (var context = new Database())
            {

                List<Product> nutrientList = new();


                var nutrients = context.Products
                    .Include(np => np.NutrientProduct)
                    .ThenInclude(n => n.Nutrient)
                    .ToList();



                foreach (var nutrient in nutrients)
                {
                    nutrientList.Add(nutrient);
                }

                return nutrientList;
            }


        }
    }
}