using FilterLearn.Filters;
using FilterLearn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FilterLearn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [ExampleActionFilter]
        [OrderAsyncActionFilter("Dhruvil Dobariya", -1)]
        public IActionResult Index()
        {
            return View();
        }
        //Before part of OrederAsyncActionFilterAttribute executed by Dhruvil Dobariya
        //Before part of ExampleActionFilter executed
        //Before part of ExampleActionFilterAttribute executed
        //After part of ExampleActionFilterAttribute executed
        //After part of ExampleActionFilter executed
        //After part of OrederAsyncActionFilterAttribute executed by Dhruvil Dobariya

        [ExampleActionFilter]
        [OrderAsyncActionFilter("Dhruvil Dobariya", 1)]
        public IActionResult Privacy()
        {
            return View();
        }
        //Before part of ExampleActionFilter executed
        //Before part of ExampleActionFilterAttribute executed
        //Before part of OrederAsyncActionFilterAttribute executed by Dhruvil Dobariya
        //After part of OrederAsyncActionFilterAttribute executed by Dhruvil Dobariya
        //After part of ExampleActionFilterAttribute executed
        //After part of ExampleActionFilter executed

        [ExampleActionFilter]
        [OrderAsyncActionFilter("Dhruvil Dobariya", 0)]
        public IActionResult About()
        {
            return View();
        }
        //Before part of ExampleActionFilter executed
        //Before part of ExampleActionFilterAttribute executed
        //Before part of OrederAsyncActionFilterAttribute executed by Dhruvil Dobariya
        //After part of OrederAsyncActionFilterAttribute executed by Dhruvil Dobariya
        //After part of ExampleActionFilterAttribute executed
        //After part of ExampleActionFilter executed

        [OrderAsyncActionFilter("Dhruvil Dobariya", 0)]
        [ExampleActionFilter]
        public IActionResult Contact()
        {
            return View();
        }
        //Before part of ExampleActionFilter executed
        //Before part of OrederAsyncActionFilterAttribute executed by Dhruvil Dobariya
        //Before part of ExampleActionFilterAttribute executed
        //After part of ExampleActionFilterAttribute executed
        //After part of OrederAsyncActionFilterAttribute executed by Dhruvil Dobariya
        //After part of ExampleActionFilter executed

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}