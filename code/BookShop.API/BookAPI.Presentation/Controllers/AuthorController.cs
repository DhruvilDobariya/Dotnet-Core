using BookAPI.BL;
using BookAPI.Domain;
using BookAPI.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace BookAPI.Presentation.Controllers
{
    /// <summary>
    /// It is controller of author
    /// </summary>
    [Route("api/[controller]s")]
    [ApiController]
    [Authorize]
    public class AuthorController : ControllerBase
    {
        #region Private Properties
        private readonly IBLAuthor _authorService;
        private readonly int _userId;
        #endregion

        #region Constructor
        public AuthorController(IBLAuthor authorService, IHttpContextAccessor contextAccessor)
        {
            _authorService = authorService;

            var identity = contextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            _userId = Convert.ToInt32(identity.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
        }
        #endregion

        #region Public Methods

        #region GetAuthorAsync
        /// <summary>
        /// Get list of Authors
        /// </summary>
        /// <returns> List of author in json</returns>
        [HttpGet]
        public async Task<IActionResult> GetAuthorAsync()
        {
            return Ok(JsonSerializer.Serialize(await _authorService.GetAllAsync(_userId)));
        }
        #endregion

        #region GetAuthorByIdAsync
        /// <summary>
        /// Get author by id
        /// </summary>
        /// <param name="id"> id represent a primary key of author table</param>
        /// <returns>author in json</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthorByIdAsync(int id)
        {
            var author = await _authorService.GetByIdAsync(id, _userId);
            if (author != null)
            {
                return Ok(JsonSerializer.Serialize(author));
            }
            return NotFound(JsonSerializer.Serialize(new MessageModel()
            {
                Message = "author not found"
            }));
        }
        #endregion

        #region AddAuthorAsync
        /// <summary>
        /// Add author in author table
        /// </summary>
        /// <param name="author">author is object which we want to add</param>
        /// <returns>Message model which contains message that author is successfully created or not</returns>
        [HttpPost]
        public async Task<IActionResult> AddAuthorAsync(BOSD01 author)
        {
            author.D01F03 = _userId;
            if (await _authorService.AddAsync(author))
            {
                return Created("", JsonSerializer.Serialize(new MessageModel()
                {
                    Message = "author added successfully"
                }));
            }
            return BadRequest(JsonSerializer.Serialize(new MessageModel()
            {
                Message = "author doesn't added successfully"
            }));
        }
        #endregion

        #region UpdateAuthorAsync
        /// <summary>
        /// update author in author table
        /// </summary>
        /// <param name="author">author is object which contains new value which we want to update</param>
        /// <returns>Message model which contains message that author is successfully updated or not</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(BOSD01 author)
        {
            author.D01F03 = _userId;
            if (await _authorService.UpdateAsync(author, _userId))
            {
                return Ok(JsonSerializer.Serialize(new MessageModel()
                {
                    Message = "author updated successfully"
                }));
            }
            return BadRequest(JsonSerializer.Serialize(new MessageModel()
            {
                Message = "author doesn't updated successfully"
            }));
        }
        #endregion

        #region DeleteAuthorAsync
        /// <summary>
        /// delete author from author table
        /// </summary>
        /// <param name="id">id represent a primary key of author which we want to delete</param>
        /// <returns>Message model which contains message that author is successfully deleted or not</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (await _authorService.DeleteAsync(id, _userId))
            {
                return Ok(JsonSerializer.Serialize(new MessageModel()
                {
                    Message = "author deleted successfully"
                }));
            }
            return NotFound(JsonSerializer.Serialize(new MessageModel()
            {
                Message = "author not found"
            }));
        }
        #endregion

        #endregion
    }
}
