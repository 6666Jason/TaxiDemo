using System.ComponentModel.DataAnnotations.Schema;
using TaxiDemo.BaseEntity;

namespace TaxiDemo.Models
{
    public class BookingPayment : BaseModel
    {
        [ForeignKey("BookingFkId")]
        public int BookingFkId { get; set; }
        public BookingModel? Booking { get; set; }

        [ForeignKey("PaymentFkId")]
        public int PaymentFkId { get; set; }
        public PaymentModel? Payment { get; set; }
    }
}
