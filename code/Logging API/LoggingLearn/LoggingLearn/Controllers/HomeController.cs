using Microsoft.AspNetCore.Mvc;

namespace LoggingLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string RunAPI()
        {
            _logger.LogTrace("Log trace executed");
            _logger.LogDebug("Log debug executed");
            _logger.LogInformation("Log information executed");
            _logger.LogWarning("Log warning executed");
            _logger.LogError("Log Error executed");
            _logger.LogCritical("Log critical executed");

            _logger.Log(LogLevel.Error, "Log error executed by log");
            _logger.LogInformation(_logger.IsEnabled(LogLevel.Information).ToString());

            // Priority of logs,
            // Trace < Debug < Information < Warning < Error < Critical < None
            return "API run successfully";
        }
    }
}
