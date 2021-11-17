using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NutrientsProject.Source;

namespace NutrientsProject.Controllers
{
    public class BasicController<T> : ControllerBase
    {
        public BasicController(ILogger<T> logger, DatabaseContext context)
        {
            _logger = logger;
            _database = context;
        }

        private ILogger<T> _logger { get; }
        protected DatabaseContext _database { get; }
    }
}