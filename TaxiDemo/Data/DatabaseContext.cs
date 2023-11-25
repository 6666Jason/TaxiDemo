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
        public DbSet<DriverModel>? Drivers { get; set; }
        public DbSet<FeedbackModel>? Feedbacks { get; set; }
        public DbSet<PaymentModel>? Payments { get; set; }
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
               .OnDelete(DeleteBehavior.NoAction);

            // Thiết lập mối quan hệ one-to-many giữa User và Driver
                modelBuilder.Entity<User>()
                .HasMany(c => c.Drivers)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserFkId)
                .OnDelete(DeleteBehavior.NoAction);

            // Thiết lập mối quan hệ one-to-many giữa RoleUser và User
            modelBuilder.Entity<User>()
                .HasOne(u => u.RoleUser)
                .WithMany(ru => ru.Users)
                .HasForeignKey(u => u.RoleUserFkId)
                .OnDelete(DeleteBehavior.NoAction);

            // Thiết lập mối quan hệ many-to-one giữa Driver và Company
            modelBuilder.Entity<CompanyModel>()
            .HasMany(c => c.Drivers)
            .WithOne(d => d.Company)
            .HasForeignKey(d => d.CompanyFkId)
            .OnDelete(DeleteBehavior.NoAction);

            // Thiết lập mối quan hệ many-to-one giữa Feedback và User
            modelBuilder.Entity<User>()
            .HasMany(c => c.Feedbacks)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.CustomerFkId)
            .OnDelete(DeleteBehavior.NoAction);

            // Thiết lập mối quan hệ many-to-one giữa Booking và User
            modelBuilder.Entity<User>()
            .HasMany(c => c.Bookings)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.CustomerFkId)
            .OnDelete(DeleteBehavior.NoAction);

            // Thiết lập mối quan hệ many-to-one giữa Advertise và Company
            modelBuilder.Entity<CompanyModel>()
            .HasMany(c => c.Advertises)
            .WithOne(a => a.Company)
            .HasForeignKey(a => a.CompanyFkId)
            .OnDelete(DeleteBehavior.NoAction);

            // Thiết lập mối quan hệ many-to-one giữa Advertise và Driver
            modelBuilder.Entity<DriverModel>()
            .HasMany(c => c.Advertises)
            .WithOne(a => a.Driver)
            .HasForeignKey(a => a.DriverFkId)
            .OnDelete(DeleteBehavior.NoAction);

            // Thiết lập mối quan hệ many-to-many giữa Booking và Company
            modelBuilder.Entity<BookingCompany>()
            .HasKey(bc => new { bc.BookingFkId, bc.CompanyFkId });

            modelBuilder.Entity<BookingCompany>()
                .HasOne(bc => bc.Booking)
                .WithMany(b => b.BookingCompanies)
                .HasForeignKey(bc => bc.BookingFkId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BookingCompany>()
                .HasOne(bc => bc.Company)
                .WithMany(c => c.BookingCompanies)
                .HasForeignKey(bc => bc.CompanyFkId)
                .OnDelete(DeleteBehavior.NoAction);

            // Thiết lập mối quan hệ many-to-many giữa Booking và Driver
            modelBuilder.Entity<BookingDriver>()
            .HasKey(bd => new { bd.BookingFkId, bd.DriverFkId });

            modelBuilder.Entity<BookingDriver>()
                .HasOne(bd => bd.Booking)
                .WithMany(b => b.BookingDrivers)
                .HasForeignKey(bd => bd.BookingFkId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BookingDriver>()
                .HasOne(bd => bd.Driver)
                .WithMany(d => d.BookingDrivers)
                .HasForeignKey(bd => bd.DriverFkId)
                .OnDelete(DeleteBehavior.NoAction);

            // Thiết lập mối quan hệ nhiều-nhiều giữa Booking và Payment thông qua BookingPayment
            modelBuilder.Entity<BookingPayment>()
            .HasKey(bp => new { bp.BookingFkId, bp.PaymentFkId });

            modelBuilder.Entity<BookingPayment>()
                .HasOne(bp => bp.Booking)
                .WithMany(b => b.BookingPayments)
                .HasForeignKey(bp => bp.BookingFkId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BookingPayment>()
                .HasOne(bp => bp.Payment)
                .WithMany(p => p.BookingPayments)
                .HasForeignKey(bp => bp.PaymentFkId)
                .OnDelete(DeleteBehavior.NoAction);

            
        }
    }
}
