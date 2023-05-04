using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiddlewareLearn.Controllers
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
        public ActionResult<string> Get()
        {
            _logger.LogInformation("Get method execute");
            return Ok("Get method called");
        }
    }
}
