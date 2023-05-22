using BookAPI.Domain;
using BookAPI.Domain.ViewModels;

namespace BookAPI.BL
{
    /// <summary>
    /// It is interface for business logic for author crud operation and authentication
    /// </summary>
    public interface IBLUser
    {
        #region Public Properties
        Task<BOSD04> GetByIdAsync(int id);
        Task<bool> AddAsync(BOSD04 user);
        Task<bool> UpdateAsync(BOSD04 user);
        Task<bool> DeleteAsync(int id);
        Task<Tokens> Authenticate(Login login);
        #endregion
    }
}
