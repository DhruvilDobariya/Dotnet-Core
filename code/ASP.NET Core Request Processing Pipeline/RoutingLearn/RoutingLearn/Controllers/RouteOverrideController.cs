using Microsoft.AspNetCore.Mvc;

namespace RoutingLearn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteOverrideController : ControllerBase
    {
        // When we use "/" in starting our existing route override, if we directly start route without "/" then it will append in existing route 
        [Route("WithoutSlash")] // Route : https://localhost:44336/api/RouteOverride/WhithoutSlash
        public IActionResult WithoutSlash()
        {
            return Ok("WithoutSlash action methods executed");
        }

        [Route("/WithSlash")] // Route : https://localhost:44336/WhithSlash
        public IActionResult WithSlash()
        {
            return Ok("WithSlash action methods executed");
        }
    }
}
