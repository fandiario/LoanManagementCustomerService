using LoanManagementCustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementCustomerService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CustomerModel> Customers { get; set; }
    }
}
