using Microsoft.AspNetCore.Mvc;

namespace LoggingLearn.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        public string ConsoleLog()
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter("Microsoft", LogLevel.Warning);
                builder.AddFilter("Default", LogLevel.Trace);
                builder.AddConsole();
            });
            ILogger<HomeController> logger = loggerFactory.CreateLogger<HomeController>();
            logger.LogInformation("Log Information");
            return "ConsoleLog run successfully";
        }

    }
}
