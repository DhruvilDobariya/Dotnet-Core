using BookAPI.DAL;
using BookAPI.Domain;

namespace BookAPI.BL.Services
{
    /// <summary>
    /// It contains business logic for customer crud operation 
    /// </summary>
    public class BLCustomer : IBLCustomer
    {
        #region Private Properties
        private readonly IDALCustomer _customerDAL;
        #endregion

        #region Constructor
        public BLCustomer(IDALCustomer customerDAL)
        {
            _customerDAL = customerDAL;
        }
        #endregion

        #region Public Methods

        #region GetAllAsync
        /// <summary>
        /// It contains business logic for retrieve a list of customer
        /// </summary>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>list of customer</returns>
        public async Task<List<BOSD02>> GetAllAsync(int userId)
        {
            try
            {
                return await _customerDAL.GetAllAsync(userId);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region GetByIdAsync
        /// <summary>
        /// It contains business logic for get single customer by id
        /// </summary>
        /// <param name="id">id represent a primary key of customer which we want to get</param>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>single customer</returns>
        public async Task<BOSD02> GetByIdAsync(int id, int userId)
        {
            try
            {
                return await _customerDAL.GetByIdAsync(id, userId);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region AddAsync
        /// <summary>
        /// It contains business logic for add single customer
        /// </summary>
        /// <param name="customer">customer is a object which we want to add in customer table</param>
        /// <returns>if recored added successfully then it return true else it return false</returns>
        public async Task<bool> AddAsync(BOSD02 customer)
        {
            try
            {
                if (await _customerDAL.AddAsync(customer) > 0)
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
        /// It contains business logic for update single customer
        /// </summary>
        /// <param name="customer">customer is a object which we want to update in customer table</param>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>if recored added successfully then it return true else it return false</returns>
        public async Task<bool> UpdateAsync(BOSD02 customer, int userId)
        {
            try
            {
                if (await _customerDAL.UpdateAsync(customer, userId) > 0)
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
        /// It contains business logic for delete single customer based on id
        /// </summary>
        /// <param name="id">id represent a primary key of customer which we want to delete</param>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>if recored added successfully then it return true else it return false</returns>
        public async Task<bool> DeleteAsync(int id, int userId)
        {
            try
            {
                if (await _customerDAL.DeleteAsync(id, userId) > 0)
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
