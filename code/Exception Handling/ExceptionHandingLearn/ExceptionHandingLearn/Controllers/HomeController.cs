using ExceptionHandingLearn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExceptionHandingLearn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calculate(int a, int b)
        {
            return Ok(a / b);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // Activity.Current?.Id: Activity.Current represents the current activity being executed.
        // HttpContext.TraceIdentifier: HttpContext represents the context of the current HTTP request being processed.
        // The TraceIdentifier property provides a unique identifier for the current request.

        // ?? operator: This is the null-coalescing operator.
        // It checks if the expression on the left side is null and, if so, evaluates the expression on the right side.

        // The request ID is used for logging and tracking purposes.
        // It allows us to correlate log messages, exceptions, and other events related to a specific request, making it easier to trace and debug issues in a distributed system.
    }
}