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
        [HttpGet(Name = "GetNutrientList")]
        public IEnumerable<Nutrient> Get()
        {
            // return Database.GetAllNutrients();
            return null;
        }

        public NutrientsController(ILogger<NutrientsController> logger, DatabaseContext context) : base(logger, context)
        {
        }
    }
}