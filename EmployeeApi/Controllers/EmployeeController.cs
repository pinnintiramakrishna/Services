using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataService.Models;
using EmployeeApi.Services;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeService _service;
        public EmployeeController(EmployeeService service) 
        {
            _service = service;

        }

        [HttpGet("AllEmployees")]
        public IEnumerable<Employee> GetAllEmployees()
        {
          return _service.GetAllEmployees();
        }

        [HttpGet("GetEmployeeById")]
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _service.GetEmployeeById(id);
        }

        [HttpPost("AddEmployee")]
        public async Task<Employee> AddEmployee(Employee employee)
        {
            return await _service.AddEmployee(employee);
        }

        [HttpPost("DeleteEmployee")]
        public void DeleteEmployee(int id)
        {
             _service.DeleteEmployee(id);
        }

        [HttpPut("UpdateEmployee")]
        public void UpdateEmployee(Employee employee)
        {
            _service.UpdateEmployee(employee);
        }

    }
}
