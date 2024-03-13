using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.Repository.Models;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Services.Models;

namespace EmployeeManagement.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            return employees.Select(emp => new EmployeeDTO
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                MiddleName = emp.MiddleName,
            });
        }

        public EmployeeDTO? GetEmployeeById(int id)
        {
            var emp = _employeeRepository.GetById(id);

            if (emp == null) return null;

            return new EmployeeDTO()
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                MiddleName = emp.MiddleName,
            };
        }

        public void AddEmployee(EmployeeDTO employee)
        {
            _employeeRepository.Add(new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
            });
        }

        public void UpdateEmployee(EmployeeDTO employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _employeeRepository.Update(new Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
            });
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.Delete(id);
        }
    }
}
