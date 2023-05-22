using BookAPI.Domain;
using BookAPI.Domain.ViewModels;

namespace BookAPI.BL
{
    /// <summary>
    /// It is interface for business logic for book crud operation 
    /// </summary>
    public interface IBLBook
    {
        #region Public Properties
        Task<List<BookWithAuthor>> GetBooksWithAuthorAsync(int userId);
        Task<BOSD03> GetByIdAsync(int id, int userId);
        Task<bool> AddAsync(BOSD03 book);
        Task<bool> UpdateAsync(BOSD03 book, int userId);
        Task<bool> DeleteAsync(int id, int userId);
        #endregion
    }
}
