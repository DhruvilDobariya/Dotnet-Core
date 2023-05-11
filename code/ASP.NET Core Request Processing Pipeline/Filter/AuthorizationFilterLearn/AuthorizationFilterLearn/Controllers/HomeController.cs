using Microsoft.AspNetCore.Mvc;

namespace AuthorizationFilterLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get method called");
        }
    }
}
