using LoanManagementCustomerService.Models;
using Microsoft.AspNetCore.Mvc;
using LoanManagementCustomerService.Data;
using Microsoft.EntityFrameworkCore;
using LoanManagementCustomerService.Interfaces;

namespace LoanManagementCustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController :ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerService _service;

        public CustomerController(ApplicationDbContext context, ICustomerService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllCustomersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetCustomerByIdAsync(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CustomerModel customer)
        {
            await _service.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerModel customer)
        {
            await _service.UpdateCustomerAsync(id, customer);
            return NoContent();
        }

        [HttpPut("delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.isActive = false;

            await _service.UpdateCustomerAsync(id, customer);
            return NoContent();
        }

        //HardDelete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}
