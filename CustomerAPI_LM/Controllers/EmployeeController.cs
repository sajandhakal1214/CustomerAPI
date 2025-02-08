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
        public IActionResult GetEmployee(int id)
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
            var updatedEmployee = _employeeService.UpdateEmployeeRecord(id, employee);

            if (updatedEmployee == null)
            {
                return NotFound("Employee not found");
            }

            return Ok(updatedEmployee);
        }


    }
}