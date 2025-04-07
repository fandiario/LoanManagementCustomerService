using LoanManagementCustomerService.Models;

namespace LoanManagementCustomerService.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetAllCustomersAsync();
        Task<CustomerModel?> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CustomerModel customer);
        Task UpdateCustomerAsync(int id, CustomerModel customer);
        Task DeleteCustomerAsync(int id);
    }
}
