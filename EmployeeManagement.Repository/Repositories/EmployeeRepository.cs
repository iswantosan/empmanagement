using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.Repository.Models;

namespace EmployeeManagement.Repository.Repositories
{
    namespace EmployeeManagement.Data
    {
        public class EmployeeRepository : IEmployeeRepository
        {
            private readonly EmployeeDbContext _dbContext;

            public EmployeeRepository(EmployeeDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public IEnumerable<Employee> GetAll()
            {
                return _dbContext.Employees.ToList();
            }

            public Employee GetById(int id)
            {
                return _dbContext.Employees.FirstOrDefault(e => e.Id == id);
            }

            public void Add(Employee employee)
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
            }

            public void Update(Employee employee)
            {
                _dbContext.Employees.Update(employee);
                _dbContext.SaveChanges();
            }

            public void Delete(int id)
            {
                var employeeToDelete = _dbContext.Employees.FirstOrDefault(e => e.Id == id);
                if (employeeToDelete != null)
                {
                    _dbContext.Employees.Remove(employeeToDelete);
                    _dbContext.SaveChanges();
                }
            }
        }
    }

}
