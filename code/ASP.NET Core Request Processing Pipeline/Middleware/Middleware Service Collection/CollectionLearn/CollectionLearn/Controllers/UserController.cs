using CollectionLearn.BL;
using CollectionLearn.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollectionLearn.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBLUserHandler _userHandler;

        public UserController(IBLUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        [HttpGet]
        public ActionResult<User> GetUsers()
        {
            return Ok(_userHandler.GetAll());
        }
    }
}
