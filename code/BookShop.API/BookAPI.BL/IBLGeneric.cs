namespace BookAPI.BL
{
    /// <summary>
    /// It is interface for business logic and data access logic for generic crud operation
    /// </summary>
    /// <typeparam name="T">T is a class which we want to generate business logic and data access logic for CRUD operation</typeparam>
    public interface IBLGeneric<T> where T : class
    {
        #region Public Properties
        Task<List<T>> GetAllAsync(int userId);
        Task<T> GetByIdAsync(int id, int userId);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity, int userId);
        Task<bool> DeleteAsync(int id, int userId);
        #endregion
    }
}
