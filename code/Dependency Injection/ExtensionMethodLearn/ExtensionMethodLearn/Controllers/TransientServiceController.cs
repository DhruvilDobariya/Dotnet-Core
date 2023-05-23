using ExtensionMethodLearn.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExtensionMethodLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransientServiceController : ControllerBase
    {
        private readonly ITransientService _transientServiceFirst;
        private readonly ITransientService _transientServiceSecond;
        public TransientServiceController(ITransientService transientServiceFirst, ITransientService transientServiceSecond)
        {
            _transientServiceFirst = transientServiceFirst;
            _transientServiceSecond = transientServiceSecond;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                firstService = _transientServiceFirst.GetHashCode(),
                secondService = _transientServiceSecond.GetHashCode(),
            });
        }
    }
}
