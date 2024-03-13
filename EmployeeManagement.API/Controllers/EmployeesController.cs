using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<EmployeeDTO> GetAll()
        {
            return _employeeService.GetAllEmployees();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(employee);
        }

        [HttpPost]
        public IActionResult Create(EmployeeDTO employee)
        {
            _employeeService.AddEmployee(employee);
            return new OkObjectResult(employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EmployeeDTO employee)
        {
            if (id != employee.Id)
            {
                return new BadRequestResult();
            }

            _employeeService.UpdateEmployee(employee);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return new NoContentResult();
        }
    }
}
