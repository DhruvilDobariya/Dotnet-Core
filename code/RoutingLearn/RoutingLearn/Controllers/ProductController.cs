using Microsoft.AspNetCore.Mvc;

namespace RoutingLearn.Controllers
{
    public class ProductController : Controller
    {
        // Product/Get
        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        // Product/Get/1
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return View();
        }

        // Product/Create
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        // Product/Update/1
        [HttpPut]
        public IActionResult Update(int id)
        {
            return View();
        }

        // Product/Delete/1
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
