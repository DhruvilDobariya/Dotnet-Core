using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NLogLearn.Controllers
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
        public string Get()
        {
            _logger.LogInformation("Log Information from get action method of home controller");
            return "Get action method of home executed";
        }
    }
}
