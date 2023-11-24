using System.ComponentModel.DataAnnotations.Schema;
using TaxiDemo.BaseEntity;

namespace TaxiDemo.Models
{
    public class RoleUser : BaseModel
    {
        public string? RoleName { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}

