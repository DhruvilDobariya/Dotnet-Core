using Microsoft.AspNetCore.Mvc;

namespace RoutingLearn.Controllers
{
    //[Route("[controller]/[action]/{:id?}")]
    public class UserController : Controller
    {
        // User/Get
        // GetUsers
        [HttpGet]
        [Route("User/Get")]
        [Route("GetUsers")]
        public IActionResult Get()
        {
            return View();
        }

        // User/Get/1
        [HttpGet]
        [Route("User/GetById/{:id}")]
        public IActionResult GetById(int id)
        {
            return View();
        }

        // User/Create
        [HttpPost]
        [Route("User/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // User/Update/1
        [HttpPut]
        [Route("User/Update/{:id}")]
        public IActionResult Update(int id)
        {
            return View();
        }

        // User/Delete/1
        [HttpDelete]
        [Route("User/Delete/{:id}")]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
