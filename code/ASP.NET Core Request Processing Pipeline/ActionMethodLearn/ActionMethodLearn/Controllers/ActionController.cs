using Microsoft.AspNetCore.Mvc;

namespace ActionMethodLearn.Controllers
{
    [Route("[controller]/[action]")]
    public class ActionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Ok()
        {
            return Ok("Ok action method called");
        }

        [HttpGet]
        public IActionResult NotFound()
        {
            return NotFound("NotFound action method called");
        }

        [HttpGet]
        public IActionResult BadRequest()
        {
            return BadRequest("BadRequest action method called");
        }

        [HttpGet]
        public IActionResult Unanuthorized()
        {
            return Unauthorized("Unauthorized action method called");
        }

        [HttpGet]
        public IActionResult Forbid()
        {
            return Forbid("Forbid action method called");
        }

        [HttpGet]
        public IActionResult Accepted()
        {
            return Accepted("Accepted action method called");
        }

        [HttpGet]
        public IActionResult Created()
        {
            return new CreatedResult("www.LocationOfCreatedResource.com", "CreatedResource");
        }

        [HttpGet]
        public IActionResult NoContentResult()
        {
            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult JsonResult()
        {
            return new JsonResult(new { id = 1, name = "Dhruvil Dobariya" });
        }

        [HttpGet]
        public IActionResult ObjectResult()
        {
            return new ObjectResult(new { id = 1, name = "Dhruvil Dobariya" });
        }

        [HttpGet]
        public IActionResult StatusCodeResult()
        {
            return new StatusCodeResult(200);
        }


        [HttpGet]
        public IActionResult RedirectResult()
        {
            return new RedirectResult("https://www.google.com");
        }


        [HttpGet]
        public IActionResult RedirectToAction()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
