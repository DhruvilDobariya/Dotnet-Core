using BookAPI.Domain;
using BookAPI.Domain.ViewModels;

namespace BookAPI.DAL
{
    /// <summary>
    /// It is interface for data access logic for author crud operation and authentication
    /// </summary>
    public interface IDALUser
    {
        #region Public Properties
        Task<BOSD04> GetByIdAsync(int id);
        Task<int> AddAsync(BOSD04 user);
        Task<int> UpdateAsync(BOSD04 user);
        Task<int> DeleteAsync(int id);
        Task<BOSD04> Authenticate(Login login);
        #endregion
    }
}
