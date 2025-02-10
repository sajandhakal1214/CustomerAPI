using CustomerAPI_LM.Interfaces;
using CustomerAPI_LM.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomerById(int id)
    {
        var customer = _customerService.GetCustomer(id);

        if (customer == null)
        {
            return NotFound("Customer not found");
        }

        return Ok(customer);
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateCustomerById(int id, [FromBody] Customer customer)
    {
        var existingCustomer = _customerService.GetCustomer(id);

        if (existingCustomer == null)
        {
            return NotFound("Customer not found"); 
        }

        _customerService.UpdateCustomerRecord(id, customer);

        return NoContent();
    }
}
