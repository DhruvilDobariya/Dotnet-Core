using BookAPI.Domain;

namespace BookAPI.BL
{
    /// <summary>
    /// It is interface for business logic for customer crud operation 
    /// </summary>
    public interface IBLCustomer
    {
        #region Public Properties
        Task<List<BOSD02>> GetAllAsync(int userId);
        Task<BOSD02> GetByIdAsync(int id, int userId);
        Task<bool> AddAsync(BOSD02 customer);
        Task<bool> UpdateAsync(BOSD02 customer, int userId);
        Task<bool> DeleteAsync(int id, int userId);
        #endregion
    }
}
