using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NutrientsProject.Source;

namespace NutrientsProject.Controllers
{
    public class BasicController<T> : ControllerBase
    {
        private ILogger<T> _logger { get; }
        protected DatabaseContext _database { get; }

        public BasicController(ILogger<T> logger, DatabaseContext context)
        {
            _logger = logger;
            _database = context;
        }
    }
}