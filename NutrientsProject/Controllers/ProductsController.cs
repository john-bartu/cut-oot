using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NutrientsProject.Source;
using Newtonsoft.Json;

namespace NutrientsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : BasicController<ProductsController>
    {
        public ProductsController(DatabaseContext context, ILogger<ProductsController> logger) : base(logger, context)
        {
        }

        [HttpGet(Name = "GetProductList")]
        public List<Product> Get()
        {
            List<Product> result =
                _database
                    .Products
                    .Include(product => product.ProductNutrients)
                    .ThenInclude(nutrient => nutrient.Nutrient)
                    .ToList();

            return result;
        }


        [HttpPost(Name = "PostProduct")]
        public Product PostProduct(Product product)
        {
            // Database.Local().Products.Add(product);
            // Database.Local().SaveChanges();
            return product;
        }
    }
}