using DependencyInjectionLearn.Domain;
using DependencyInjectionLearn.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjectionLearn.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _dbContext;
        public EmployeeService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Employee>> GetAsync()
        {
            try
            {
                return await _dbContext.Employees.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.EmployeeId == id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> AddAsync(Employee employee)
        {
            try
            {
                await _dbContext.Employees.AddAsync(employee);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            try
            {
                _dbContext.Employees.Update(employee);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Employee employee = await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.EmployeeId == id);

                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

    }
}
