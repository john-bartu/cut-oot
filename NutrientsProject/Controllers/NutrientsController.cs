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
        public IEnumerable<Nutrient> Get()
        {
            return Database.GetAllNutrients();
        }
    }
}