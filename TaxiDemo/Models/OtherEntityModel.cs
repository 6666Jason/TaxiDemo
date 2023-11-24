namespace TaxiDemo.Models
{
    public class OtherEntityModel
    {
        public int Id { get; set; }

        // Foreign key to UserModel
        public int UserFkId { get; set; }
        public User? User { get; set; }
    }
}
