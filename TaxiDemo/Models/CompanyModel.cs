using TaxiDemo.BaseEntity;

namespace TaxiDemo.Models
{
    public class CompanyModel : BaseModel
    {
        public string? Name { get; set; }
        public string? Role { get; set; }
        public string? Password { get; set; }
        public string? ContactPerson { get; set; }
        public string? Designation { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? Telephone { get; set; }
        public string? FaxNumber { get; set; }
        public string? Email { get; set; }
        public string? MembershipType { get; set; }
        public string? PaymentType { get; set; }

        public List<DriverModel>? Drivers { get; set; }
        public List<AdvertiseModel>? Advertises { get; set; }

        public List<BookingCompany>? BookingCompanies { get; set; }
    }
}
