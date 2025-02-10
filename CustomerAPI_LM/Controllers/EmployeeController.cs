using CustomerAPI_LM.Interfaces;
using CustomerAPI_LM.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI_LM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }
            return Ok(employee);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateEmployeeById(int id, [FromBody] Employee employee)
        {
            var existingEmployee = _employeeService.GetEmployee(id);

            if (existingEmployee == null)
            {
                return NotFound("Employee not found");
            }

            _employeeService.UpdateEmployeeRecord(id, employee);

            return NoContent();
        }


    }
}