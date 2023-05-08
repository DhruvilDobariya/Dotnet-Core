using Microsoft.EntityFrameworkCore;

namespace DependencyInjectionLearn.Domain.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
