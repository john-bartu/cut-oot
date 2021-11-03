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
    public class ProductsController : BasicController<ProductsController>
    {
        public ProductsController(ILogger<ProductsController> logger) : base(logger)
        {
        }

        [HttpGet(Name = "GetProductList")]
        public IEnumerable<Product> Get()
        {
            return Database.GetAllProductsWithNutrients();
        }
    }
}