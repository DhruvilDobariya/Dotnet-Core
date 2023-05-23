using ExtensionMethodLearn.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExtensionMethodLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScopedServiceController : ControllerBase
    {
        private readonly IScopedService _scopedServiceFirst;
        private readonly IScopedService _scopedServiceSecond;
        public ScopedServiceController(IScopedService scopedServiceFirst, IScopedService scopedServiceSecond)
        {
            _scopedServiceFirst = scopedServiceFirst;
            _scopedServiceSecond = scopedServiceSecond;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                firstService = _scopedServiceFirst.GetHashCode(), // every instance have unique hash code
                secondService = _scopedServiceSecond.GetHashCode(),
            });
        }
    }
}
