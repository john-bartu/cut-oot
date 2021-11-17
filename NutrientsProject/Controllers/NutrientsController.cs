using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NutrientsProject.Source;

namespace NutrientsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NutrientsController : BasicController<NutrientsController>
    {
        public NutrientsController(ILogger<NutrientsController> logger, DatabaseContext context) : base(logger, context)
        {
        }

        [HttpGet(Name = "GetNutrientList")]
        public IEnumerable<Nutrient> Get()
        {
            // return Database.GetAllNutrients();
            return null;
        }
    }
}