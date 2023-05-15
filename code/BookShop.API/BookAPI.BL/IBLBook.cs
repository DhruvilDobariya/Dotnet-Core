using BookAPI.Domain;
using BookAPI.Domain.ViewModels;

namespace BookAPI.BL
{
    /// <summary>
    /// It is interface for business logic and data access logic for book crud operation 
    /// </summary>
    public interface IBLBook : IBLGeneric<BOSD03>
    {
        Task<List<BookWithAuthor>> GetBooksWithAuthorAsync(int userId);
    }
}
