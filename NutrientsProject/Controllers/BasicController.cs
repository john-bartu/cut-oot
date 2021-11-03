using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NutrientsProject.Controllers
{
    public class BasicController<T> : ControllerBase
    {
        private readonly ILogger<T> _logger;

        public BasicController(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}
