using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingLearn.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        // Product/Get
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Products");
        }

        // Product/Get/1
        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            return Ok($"Product: {id}");
        }

        // Product/Create
        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Products created");
        }

        // Product/Update/1
        [HttpPut]
        public IActionResult Update(int id)
        {
            return Ok($"Products: {id} updated");
        }

        // Product/Delete/1
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok("Product deleted");
        }

    }
}
