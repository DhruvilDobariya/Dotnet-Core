namespace AddressBook.BL
{
    public interface IBLGeneric<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetBuIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
