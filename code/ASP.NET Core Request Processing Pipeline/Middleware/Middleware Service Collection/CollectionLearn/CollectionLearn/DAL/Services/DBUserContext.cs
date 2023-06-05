using CollectionLearn.Models;

namespace CollectionLearn.DAL.Services
{
    public class DBUserContext : IDBUserContext
    {
        private readonly List<User> _users = new List<User>()
        {
            new User() { Id = 1, Name = "Dhruvil Dobariya", Email = "dhruvil@gmail.com", Password = "Dhruvil@123"},
            new User() { Id = 2, Name = "Dhaval Dobariya", Email = "dhaval@gmail.com", Password = "Dhaval@123"},
            new User() { Id = 3, Name = "Jenil Vasoya", Email = "jenil@gmail.com", Password = "Jenil@123"},
            new User() { Id = 4, Name = "Bhargav Vachhani", Email = "bhargav@gmail.com", Password = "Bhargav@123"},
            new User() { Id = 5, Name = "Dhruv Rathod", Email = "dhruv@gmail.com", Password = "Dhruv@123"}
        };

        public List<User> GetAll()
        {
            return _users;
        }
    }
}
