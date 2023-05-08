using DependencyInjectionLearn.Domain;

namespace DependencyInjectionLearn.Infrastructure
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<bool> AddAsync(Employee employee);
        Task<bool> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(int id);
    }
}