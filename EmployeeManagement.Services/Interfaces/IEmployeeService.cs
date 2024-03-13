using EmployeeManagement.Services.Models;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetAllEmployees();
        EmployeeDTO? GetEmployeeById(int id);
        void AddEmployee(EmployeeDTO employee);
        void UpdateEmployee(EmployeeDTO employee);
        void DeleteEmployee(int id);
    }
}
