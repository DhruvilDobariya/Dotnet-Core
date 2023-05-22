using BookAPI.BL;
using BookAPI.Domain;
using BookAPI.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.API.Controllers
{
    /// <summary>
    /// It is controller of user
    /// </summary>
    [Route("api/[controller]s")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        #region Private Properties
        private readonly IBLUser _userService;
        private readonly int _userId = 1;
        #endregion

        #region Constructor
        public UserController(IBLUser userService)
        {
            _userService = userService;

            //var identity = httpContext.User.Identity as ClaimsIdentity;
            //int.TryParse(identity.Claims.FirstOrDefault(x => x.Type == "UserId").Value, out userId);
        }
        #endregion

        #region Public Methods

        #region Authenticate
        /// <summary>
        /// Get Jwt token
        /// </summary>
        /// <param name = "login" > login object of Login class which contains email and password of user</param>
        /// <returns>It gives JWT token</returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(Login login)
        {
            var token = await _userService.Authenticate(login);
            if (token != null)
            {
                return Ok(token);
            }
            return Unauthorized(new MessageModel()
            {
                Message = "username or password can't match"
            });
        }
        #endregion

        #region GetUserByIdAsync
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"> id represent a primary key of user table</param>
        /// <returns>user in json</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound(new MessageModel() { Message = "user not found" });
        }
        #endregion

        #region AddUserAsync
        /// <summary>
        /// Add user in user table
        /// </summary>
        /// <param name="user">user is object which we want to add</param>
        /// <returns>Message model which contains message that user is successfully created or not</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddUserAsync(BOSD04 user)
        {
            if (await _userService.AddAsync(user))
            {
                return Created("", new MessageModel() { Message = "user added successfully" });
            }
            return BadRequest(new MessageModel() { Message = "user doesn't added successfully" });
        }
        #endregion

        #region UpdateUserAsync
        /// <summary>
        /// update user in user table
        /// </summary>
        /// <param name="user">user is object which contains new value which we want to update</param>
        /// <returns>Message model which contains message that user is successfully updated or not</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUser(BOSD04 user)
        {
            user.D04F01 = _userId;
            if (await _userService.UpdateAsync(user))
            {
                return Ok(new MessageModel() { Message = "user updated successfully" });
            }
            return BadRequest(new MessageModel() { Message = "user doesn't updated successfully" });
        }
        #endregion

        #region DeleteUserAsync
        /// <summary>
        /// delete user from user table
        /// </summary>
        /// <param name="id">id represent a primary key of user which we want to delete</param>
        /// <returns>Message model which contains message that user is successfully deleted or not</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (await _userService.DeleteAsync(id))
            {
                return Ok(new MessageModel() { Message = "user deleted successfully" });
            }
            return NotFound(new MessageModel() { Message = "user not found" });
        }
        #endregion

        #endregion
    }
}
