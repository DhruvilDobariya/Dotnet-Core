namespace AddressBook.BL.Services
{
    public class CRUDService<T> : ICRUDService<T> where T : class
    {
        private readonly string _connectionString;
        private readonly string _tableName;
        public CRUDService(string connectionString, string tableName) 
        {
            _connectionString = connectionString;
            _tableName = tableName;
        }
    }
}
