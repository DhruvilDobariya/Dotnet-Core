using CollectionLearn.DAL;
using CollectionLearn.Models;

namespace CollectionLearn.BL.Services
{
    public class BLUserHandler : IBLUserHandler
    {
        private readonly IDBUserContext _context;

        public BLUserHandler(IDBUserContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.GetAll();
        }
    }
}
