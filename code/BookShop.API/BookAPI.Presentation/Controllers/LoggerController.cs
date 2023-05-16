using Microsoft.AspNetCore.Mvc;
using NLog;

namespace BookAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class LoggerController : ControllerBase
    {
        private readonly NLog.ILogger _logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public int Get(int a, int b)
        {
            return a / b;
        }
    }
}
