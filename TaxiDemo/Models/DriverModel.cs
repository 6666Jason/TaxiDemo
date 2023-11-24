using System.ComponentModel.DataAnnotations.Schema;
using TaxiDemo.BaseEntity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TaxiDemo.Models
{
    public class DriverModel : BaseModel
    {
        [ForeignKey("CompanyFkId")]
        public int CompanyFkId { get; set; }  // Foreign Key to link with the Company model
        public string? ContactPerson { get; set; }
        public string? City { get; set; }
        public string? Mobile { get; set; }
        public string? Telephone { get; set; }
        public int Experience { get; set; }
        public string? Description { get; set; }
        public string? PaymentType { get; set; }
        public CompanyModel? Company { get; set; }
        [ForeignKey("UserFkId")]
        public int UserFkId { get; set; }
        public User? User { get; set; }
        public virtual ICollection<CarModel>? Cars { get; set; } // Navigation property

        public virtual ICollection<BookingDriver>? BookingDrivers { get; set; } = new HashSet<BookingDriver>();

        
    }
}
