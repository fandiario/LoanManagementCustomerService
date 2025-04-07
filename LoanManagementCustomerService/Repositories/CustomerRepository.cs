using LoanManagementCustomerService.Data;
using LoanManagementCustomerService.Interfaces;
using LoanManagementCustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementCustomerService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) { 
            _context = context;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }
           

        public async Task<CustomerModel?> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }
            
        public async Task AddAsync(CustomerModel customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomerModel customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
