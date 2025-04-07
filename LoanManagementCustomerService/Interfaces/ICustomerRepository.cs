using LoanManagementCustomerService.Models;

namespace LoanManagementCustomerService.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerModel>> GetAllAsync();
        Task<CustomerModel?> GetByIdAsync(int id);
        Task AddAsync(CustomerModel customer);
        Task UpdateAsync(CustomerModel customer);
        Task DeleteAsync(int id);
    }
}
