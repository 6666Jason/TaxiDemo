﻿using System.ComponentModel.DataAnnotations.Schema;
using TaxiDemo.BaseEntity;

namespace TaxiDemo.Models
{
    public class BookingModel : BaseModel
    {
        [ForeignKey("CustomerFkId")]
        public int CustomerFkId { get; set; }  // Foreign Key to link with the Customer model
        [ForeignKey("CompanyFkId")]
        public int CompanyFkId { get; set; }   // Foreign Key to link with the Company model
        [ForeignKey("DriverFkId")]
        public int DriverFkId { get; set; }    // Foreign Key to link with the Driver model
        public DateTime PickupDateTime { get; set; }
        public DateTime DropDateTime { get; set; }
        public string? PickupLocation { get; set; }
        public string? DropLocation { get; set; }
        public BookingStatus Status { get; set; }
        public CustomerModel? Customer { get; set; }
        public List<BookingPayment>? BookingPayments { get; set; }
        public List<BookingCompany>? BookingCompanies { get; set; }
        public List<BookingDriver>? BookingDrivers { get; set; }
    }

    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Completed,
        Canceled
    }
}