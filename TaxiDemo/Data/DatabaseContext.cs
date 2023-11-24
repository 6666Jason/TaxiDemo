using Microsoft.EntityFrameworkCore;
using TaxiDemo.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TaxiDemo.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<AdvertiseModel>? Advertises { get; set; }
        public DbSet<BookingModel>? Bookings { get; set; }
        public DbSet<CompanyModel>? Companies { get; set; }
        public DbSet<CustomerModel>? Customers { get; set; }
        public DbSet<DriverModel>? Drivers { get; set; }
        public DbSet<FeedbackModel>? Feedbacks { get; set; }
        public DbSet<PaymentModel>? Payments { get; set; }
        public DbSet<CarModel>? Cars { get; set; }
        public DbSet<BookingPayment>? BookingPayments { get; set; }
        public DbSet<BookingCompany>? BookingCompanies { get; set; }

        public DbSet<BookingDriver>? BookingDrivers { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<RoleUser>? RoleUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Thiết lập mối quan hệ one-to-one giữa User và Company
            modelBuilder.Entity<User>()
               .HasOne(u => u.Company)
               .WithOne(c => c.User)
               .HasForeignKey<CompanyModel>(c => c.UserFkId)
               .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập mối quan hệ one-to-many giữa User và Driver
            modelBuilder.Entity<User>()
            .HasMany(u => u.Drivers)
            .WithOne(d => d.User)
            .HasForeignKey(d => d.UserFkId)
            .OnDelete(DeleteBehavior.Restrict); // Sửa từ Cascade thành Restrict

            modelBuilder.Entity<User>()
                .HasMany(u => u.OtherEntities)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserFkId)
                .OnDelete(DeleteBehavior.Restrict); // Hoặc sửa từ Cascade thành Restrict

            // Thiết lập mối quan hệ one-to-many giữa RoleUser và User
            modelBuilder.Entity<User>()
                .HasOne(u => u.RoleUser)
                .WithMany(ru => ru.Users)
                .HasForeignKey(u => u.RoleUserFkId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập mối quan hệ many-to-one giữa Driver và Company
            modelBuilder.Entity<CompanyModel>()
            .HasMany(c => c.Drivers)
            .WithOne(d => d.Company)
            .HasForeignKey(d => d.CompanyFkId)
            .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập mối quan hệ many-to-one giữa Customer và Feedback
            modelBuilder.Entity<CustomerModel>()
            .HasMany(c => c.Feedbacks)
            .WithOne(f => f.Customer)
            .HasForeignKey(f => f.CustomerFkId)
            .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập mối quan hệ many-to-one giữa Customer và Booking
            modelBuilder.Entity<CustomerModel>()
            .HasMany(c => c.Bookings)
            .WithOne(b => b.Customer)
            .HasForeignKey(b => b.CustomerFkId)
            .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập mối quan hệ many-to-one giữa Company và Advertise  
            modelBuilder.Entity<CompanyModel>()
            .HasMany(c => c.Advertises)
            .WithOne(a => a.Company)
            .HasForeignKey(a => a.CompanyFkId)
            .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập mối quan hệ many-to-many giữa Booking và Company
            modelBuilder.Entity<BookingCompany>()
            .HasKey(bc => new { bc.BookingFkId, bc.CompanyFkId });

            modelBuilder.Entity<BookingCompany>()
                .HasOne(bc => bc.Booking)
                .WithMany(b => b.BookingCompanies)
                .HasForeignKey(bc => bc.BookingFkId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingCompany>()
                .HasOne(bc => bc.Company)
                .WithMany(c => c.BookingCompanies)
                .HasForeignKey(bc => bc.CompanyFkId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập mối quan hệ many-to-many giữa Booking và Driver
            modelBuilder.Entity<BookingDriver>()
            .HasKey(bd => new { bd.BookingFkId, bd.DriverFkId });

            modelBuilder.Entity<BookingDriver>()
                .HasOne(bd => bd.Booking)
                .WithMany(b => b.BookingDrivers)
                .HasForeignKey(bd => bd.BookingFkId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingDriver>()
                .HasOne(bd => bd.Driver)
                .WithMany(d => d.BookingDrivers)
                .HasForeignKey(bd => bd.DriverFkId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập mối quan hệ nhiều-nhiều giữa Booking và Payment thông qua BookingPayment
            modelBuilder.Entity<BookingPayment>()
            .HasKey(bp => new { bp.BookingFkId, bp.PaymentFkId });

            modelBuilder.Entity<BookingPayment>()
                .HasOne(bp => bp.Booking)
                .WithMany(b => b.BookingPayments)
                .HasForeignKey(bp => bp.BookingFkId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingPayment>()
                .HasOne(bp => bp.Payment)
                .WithMany(p => p.BookingPayments)
                .HasForeignKey(bp => bp.PaymentFkId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập mối quan hệ many-to-one giữa Driver và Car
            modelBuilder.Entity<CarModel>()
            .HasKey(c => c.Id);

            modelBuilder.Entity<DriverModel>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<CarModel>()
                .HasOne(c => c.Driver)
                .WithMany(d => d.Cars)
                .HasForeignKey(c => c.DriverFkId)
                .OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}
