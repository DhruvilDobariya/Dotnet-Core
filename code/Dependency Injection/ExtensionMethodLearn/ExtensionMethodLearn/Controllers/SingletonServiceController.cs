using ExtensionMethodLearn.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExtensionMethodLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingletonServiceController : ControllerBase
    {
        private readonly ISingletonService _singletonServiceFirst;
        private readonly ISingletonService _singletonServiceSecond;
        public SingletonServiceController(ISingletonService singletonServiceFirst, ISingletonService singletonServiceSecond)
        {
            _singletonServiceFirst = singletonServiceFirst;
            _singletonServiceSecond = singletonServiceSecond;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                firstService = _singletonServiceFirst.GetHashCode(),
                secondService = _singletonServiceSecond.GetHashCode(),
            });
        }
    }
}
