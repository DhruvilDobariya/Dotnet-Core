using BookAPI.BL;
using BookAPI.Domain;
using BookAPI.Domain.ViewModels;
using BookAPI.Presentation.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BookAPI.API.Controllers
{
    /// <summary>
    /// It is controller of book
    /// </summary>
    [Route("api/[controller]s")]
    [ApiController]
    [ModelValidationFilter]
    [Authorize]
    public class BookController : ControllerBase
    {
        #region Private Properties
        private readonly IBLBook _bookService;
        private readonly int _userId = 1;
        #endregion

        #region Constructor
        public BookController(IBLBook bookService)
        {
            _bookService = bookService;

            //var identity = httpContext.User.Identity as ClaimsIdentity;
            //int.TryParse(identity.Claims.FirstOrDefault(x => x.Type == "UserId").Value, out userId);
        }
        #endregion

        #region Public Methods

        #region GetBookAsync
        /// <summary>
        /// Get list of books
        /// </summary>
        /// <returns> List of book in json</returns>
        [HttpGet]
        public async Task<IActionResult> GetBookAsync()
        {
            return Ok(JsonSerializer.Serialize(await _bookService.GetBooksWithAuthorAsync(_userId)));
        }
        #endregion

        #region GetBookByIdAsync
        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id"> id represent a primary key of book table</param>
        /// <returns>book in json</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var book = await _bookService.GetByIdAsync(id, _userId);
            if (book != null)
            {
                return Ok(JsonSerializer.Serialize(book));
            }
            return NotFound(JsonSerializer.Serialize(new MessageModel()
            {
                Message = "book not found"
            }));
        }
        #endregion

        #region AddBookAsync
        /// <summary>
        /// Add book in book table
        /// </summary>
        /// <param name="book">book is object which we want to add</param>
        /// <returns>Message model which contains message that book is successfully created or not</returns>
        [HttpPost]
        public async Task<IActionResult> AddBookAsync(BOSD03 book)
        {
            book.D03F07 = _userId;
            if (await _bookService.AddAsync(book))
            {
                return Created("", JsonSerializer.Serialize(new MessageModel()
                {
                    Message = "book added successfully"
                }));
            }
            return BadRequest(JsonSerializer.Serialize(new MessageModel()
            {
                Message = "book doesn't added successfully"
            }));
        }
        #endregion

        #region UpdateBookAsync
        /// <summary>
        /// update book in book table
        /// </summary>
        /// <param name="book">book is object which contains new value which we want to update</param>
        /// <returns>Message model which contains message that book is successfully updated or not</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateBook(BOSD03 book)
        {
            book.D03F07 = _userId;
            if (await _bookService.UpdateAsync(book, _userId))
            {
                return Ok(JsonSerializer.Serialize(new MessageModel()
                {
                    Message = "book updated successfully"
                }));
            }
            return BadRequest(JsonSerializer.Serialize(new MessageModel()
            {
                Message = "book doesn't updated successfully"
            }));
        }
        #endregion

        #region DeleteBookAsync
        /// <summary>
        /// delete book from book table
        /// </summary>
        /// <param name="id">id represent a primary key of book which we want to delete</param>
        /// <returns>Message model which contains message that book is successfully deleted or not</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (await _bookService.DeleteAsync(id, _userId))
            {
                return Ok(JsonSerializer.Serialize(new MessageModel()
                {
                    Message = "book deleted successfully"
                }));
            }
            return NotFound(JsonSerializer.Serialize(new MessageModel()
            {
                Message = "book not found"
            }));
        }
        #endregion

        #endregion
    }
}
