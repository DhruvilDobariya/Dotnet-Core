namespace BookAPI.DAL
{
    /// <summary>
    /// It is interface for data access logic for generic crud operation
    /// </summary>
    /// <typeparam name="T">T is a class which we want to generate data access logic for CRUD operation</typeparam>
    public interface IDALGeneric<T> where T : class
    {
        #region Public Properties
        Task<List<T>> GetAllAsync(int userId);
        Task<T> GetByIdAsync(int id, int userId);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity, int userId);
        Task<int> DeleteAsync(int id, int userId);
        #endregion
    }
}
