using Microsoft.AspNetCore.Mvc;
using ResultFilterLearn.Filters;
using System.Diagnostics;

namespace ResultFilterLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [TypeFilter(typeof(CustomResultFilter))]
        public IActionResult Get()
        {
            Debug.WriteLine("Get Method called");
            return Ok("Get action method called");
        }
    }
}
