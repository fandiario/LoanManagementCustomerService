using LoanManagementCustomerService.Interfaces;
using LoanManagementCustomerService.Models;

namespace LoanManagementCustomerService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomersAsync()
        {
            return await _repository.GetAllAsync();
        }
           
        public async Task<CustomerModel?> GetCustomerByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
            

        public async Task AddCustomerAsync(CustomerModel customer)
        {
            customer.CreatedAt = DateTime.UtcNow;
            customer.LastUpdatedAt = DateTime.UtcNow;
            await _repository.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync(int id, CustomerModel customer)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return;

            existing.NIK = customer.NIK;
            existing.Name = customer.Name;
            existing.Address = customer.Address;
            existing.Telephone = customer.Telephone;
            existing.LastUpdatedBy = customer.LastUpdatedBy;
            existing.LastUpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteCustomerAsync(int id) =>
            await _repository.DeleteAsync(id);
    }

}
