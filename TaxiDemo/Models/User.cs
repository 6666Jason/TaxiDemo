using System.ComponentModel.DataAnnotations.Schema;
using TaxiDemo.BaseEntity;

namespace TaxiDemo.Models
{
    public class User : BaseModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Role { get; set; }
        public CompanyModel? Company { get; set; }
        [ForeignKey("RoleUserFkId")]
        public int RoleUserFkId { get; set; }
        public RoleUser? RoleUser { get; set; }
        public virtual ICollection<DriverModel>? Drivers { get; set; }
        // Khóa ngoại để liên kết với OtherEntities
        public int OtherEntitiesFkId { get; set; }
        public ICollection<OtherEntityModel>? OtherEntities { get; set; }
    }
}
