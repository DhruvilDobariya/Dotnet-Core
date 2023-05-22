using BookAPI.Domain;

namespace BookAPI.BL
{
    /// <summary>
    /// It is interface for business logic for author crud operation 
    /// </summary>
    public interface IBLAuthor
    {
        #region Public Properties
        Task<List<BOSD01>> GetAllAsync(int userId);
        Task<BOSD01> GetByIdAsync(int id, int userId);
        Task<bool> AddAsync(BOSD01 author);
        Task<bool> UpdateAsync(BOSD01 author, int userId);
        Task<bool> DeleteAsync(int id, int userId);
        #endregion
    }
}
