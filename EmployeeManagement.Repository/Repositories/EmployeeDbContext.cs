using EmployeeManagement.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository.Repositories
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}