using System.ComponentModel.DataAnnotations.Schema;
using TaxiDemo.BaseEntity;

namespace TaxiDemo.Models
{
    public class CarModel : BaseModel
    {
        [ForeignKey("DriverFkId")]
        public int DriverFkId { get; set; }
        public DriverModel? Driver { get; set; } // Navigation property
        public string? Brand { get; set; }   // Thương hiệu
        public string? Model { get; set; }   // Mô hình
        public int Year { get; set; }       // Năm sản xuất
        public string? Color { get; set; }   // Màu sắc
        public string? LicensePlate { get; set; } // Biển số xe

    }
}
