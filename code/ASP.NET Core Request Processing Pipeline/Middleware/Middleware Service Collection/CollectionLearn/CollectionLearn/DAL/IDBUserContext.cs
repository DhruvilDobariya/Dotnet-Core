using CollectionLearn.Models;

namespace CollectionLearn.DAL
{
    public interface IDBUserContext
    {
        List<User> GetAll();
    }
}
