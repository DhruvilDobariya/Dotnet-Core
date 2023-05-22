using BookAPI.Domain;
using BookAPI.Domain.ViewModels;

namespace BookAPI.DAL
{
    /// <summary>
    /// It is interface for data access logic for book crud operation 
    /// </summary>
    public interface IDALBook : IDALGeneric<BOSD03>
    {
        Task<List<BookWithAuthor>> GetBooksWithAuthorAsync(int userId);
    }
}
