using BookAPI.DAL;
using BookAPI.Domain;

namespace BookAPI.BL.Services
{
    /// <summary>
    /// It contains business logic for author crud operation 
    /// </summary>
    public class BLAuthor : IBLAuthor
    {
        #region Private Properties
        private readonly IDALAuthor _authorDAL;
        #endregion

        #region Constructor
        public BLAuthor(IDALAuthor authorDAL)
        {
            _authorDAL = authorDAL;
        }
        #endregion

        #region Public Methods

        #region GetAllAsync
        /// <summary>
        /// It contains business logic for retrieve a list of author
        /// </summary>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>list of author</returns>
        public async Task<List<BOSD01>> GetAllAsync(int userId)
        {
            try
            {
                return await _authorDAL.GetAllAsync(userId);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region GetByIdAsync
        /// <summary>
        /// It contains business logic for get single author by id
        /// </summary>
        /// <param name="id">id represent a primary key of author which we want to get</param>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>single author</returns>
        public async Task<BOSD01> GetByIdAsync(int id, int userId)
        {
            try
            {
                return await _authorDAL.GetByIdAsync(id, userId);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region AddAsync
        /// <summary>
        /// It contains business logic for add single author
        /// </summary>
        /// <param name="author">author is a object which we want to add in author table</param>
        /// <returns>if recored added successfully then it return true else it return false</returns>
        public async Task<bool> AddAsync(BOSD01 author)
        {
            try
            {
                if (await _authorDAL.AddAsync(author) > 0)
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
        /// It contains business logic for update single author
        /// </summary>
        /// <param name="author">author is a object which we want to update in author table</param>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>if recored added successfully then it return true else it return false</returns>
        public async Task<bool> UpdateAsync(BOSD01 author, int userId)
        {
            try
            {
                if (await _authorDAL.UpdateAsync(author, userId) > 0)
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
        /// It contains business logic for delete single author based on id
        /// </summary>
        /// <param name="id">id represent a primary key of author which we want to delete</param>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>if recored added successfully then it return true else it return false</returns>
        public async Task<bool> DeleteAsync(int id, int userId)
        {
            try
            {
                if (await _authorDAL.DeleteAsync(id, userId) > 0)
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
