using Microsoft.AspNetCore.Mvc;

namespace ExceptionFilterLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int a, int b)
        {
            return Ok(a / b);
        }
    }
}
