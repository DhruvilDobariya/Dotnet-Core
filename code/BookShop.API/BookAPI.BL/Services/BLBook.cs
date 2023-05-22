using BookAPI.DAL;
using BookAPI.Domain;
using BookAPI.Domain.ViewModels;

namespace BookAPI.BL.Services
{
    /// <summary>
    /// It contains business logic for book crud operation 
    /// </summary>
    public class BLBook : IBLBook
    {
        #region Private Properties
        private readonly IDALBook _bookDAL;
        #endregion

        #region Constructor
        public BLBook(IDALBook bookDAL)
        {
            _bookDAL = bookDAL;
        }
        #endregion

        #region Public Methods

        #region GetAllAsync
        /// <summary>
        /// It contains business logic for retrieve a list of book
        /// </summary>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>list of book</returns>
        public async Task<List<BookWithAuthor>> GetBooksWithAuthorAsync(int userId)
        {
            try
            {
                return await _bookDAL.GetBooksWithAuthorAsync(userId);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region GetByIdAsync
        /// <summary>
        /// It contains business logic for get single book by id
        /// </summary>
        /// <param name="id">id represent a primary key of book which we want to get</param>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>single book</returns>
        public async Task<BOSD03> GetByIdAsync(int id, int userId)
        {
            try
            {
                return await _bookDAL.GetByIdAsync(id, userId);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region AddAsync
        /// <summary>
        /// It contains business logic for add single book
        /// </summary>
        /// <param name="book">book is a object which we want to add in book table</param>
        /// <returns>if recored added successfully then it return true else it return false</returns>
        public async Task<bool> AddAsync(BOSD03 book)
        {
            try
            {
                if (await _bookDAL.AddAsync(book) > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region UpdateAsync
        /// <summary>
        /// It contains business logic for update single book
        /// </summary>
        /// <param name="book">book is a object which we want to update in book table</param>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>if recored added successfully then it return true else it return false</returns>
        public async Task<bool> UpdateAsync(BOSD03 book, int userId)
        {
            try
            {
                if (await _bookDAL.UpdateAsync(book, userId) > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region DeleteAsync
        /// <summary>
        /// It contains business logic for delete single book based on id
        /// </summary>
        /// <param name="id">id represent a primary key of book which we want to delete</param>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>if recored added successfully then it return true else it return false</returns>
        public async Task<bool> DeleteAsync(int id, int userId)
        {
            try
            {
                if (await _bookDAL.DeleteAsync(id, userId) > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #endregion
    }
}
