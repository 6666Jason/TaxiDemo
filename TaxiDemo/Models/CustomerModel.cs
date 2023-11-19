using TaxiDemo.BaseEntity;

namespace TaxiDemo.Models
{
    public class CustomerModel : BaseModel
    {
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalCost { get; set; }
        public decimal MoneySpent { get; set; }

        public List<FeedbackModel>? Feedbacks { get; set; }
        public List<BookingModel>? Bookings { get; set; }
    }
}
