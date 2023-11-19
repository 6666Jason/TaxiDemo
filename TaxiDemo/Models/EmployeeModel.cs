using TaxiDemo.BaseEntity;

namespace TaxiDemo.Models
{
    public class EmployeeModel : BaseModel
    {
        public string? EmployeeName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
