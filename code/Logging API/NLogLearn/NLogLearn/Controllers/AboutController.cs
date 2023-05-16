using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NLogLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly ILogger<AboutController> _logger;
        public AboutController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("Log Information from get action method of about controller");
            return "Get action method of about executed";
        }
    }
}
