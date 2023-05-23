using Microsoft.AspNetCore.Mvc;

namespace RunUseLearn.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get");
        }

        [HttpGet]
        public IActionResult GetMap()
        {
            return Ok("Get Map");
        }

        [HttpGet]
        public IActionResult GetWhen()
        {
            return Ok("Get When");
        }
    }
}
