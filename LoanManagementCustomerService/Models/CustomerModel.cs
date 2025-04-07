using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementCustomerService.Models
{
    [Table("MasterCustomer")]
    public class CustomerModel
    {
        public int Id { get; set; }
        public int NIK { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public int LastUpdatedBy { get; set; }
        public bool isActive {get; set; }
    }
}
