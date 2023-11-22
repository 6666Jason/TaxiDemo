using System.ComponentModel.DataAnnotations.Schema;
using TaxiDemo.BaseEntity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TaxiDemo.Models
{
    public class DriverModel : BaseModel
    {
        public string? DriverName { get; set; }
        public string? Role { get; set; }
        [ForeignKey("CompanyFkId")]
        public int CompanyFkId { get; set; }  // Foreign Key to link with the Company model
        public string? Password { get; set; }
        public string? ContactPerson { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Mobile { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public int Experience { get; set; }
        public string? Description { get; set; }
        public string? PaymentType { get; set; }
        public CompanyModel? Company { get; set; }

        public List<CarModel>? Cars { get; set; } // Navigation property

        public virtual ICollection<BookingDriver>? BookingDrivers { get; set; } = new HashSet<BookingDriver>();
    }
}
