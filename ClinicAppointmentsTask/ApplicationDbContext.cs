// API versioning and Swagger API documentation can be applied for maintaining and documenting the Rest API.

using ClinicAppointmentsTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentsTask
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public ApplicationDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Use SQL Server as the database provider
                optionsBuilder.UseSqlServer("YourConnectionStringHere");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite primary key for Booking (PId, CId, DateToday)
            modelBuilder.Entity<Booking>()
                .HasKey(b => new { b.PatientId, b.ClinicId, b.DateToday });

            // Relationships: Booking -> Patient (Many-to-One)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Patient)
                .WithMany(p => p.Booking)
                .HasForeignKey(b => b.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationships: Booking -> Clinic (Many-to-One)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Clinic)
                .WithMany(c => c.Booking)
                .HasForeignKey(b => b.ClinicId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint: Clinic specialization must be unique
            modelBuilder.Entity<Clinic>()
                .HasIndex(c => c.ClinicSepcialization)
                .IsUnique();

            // Additional configurations (default values, max lengths)
            modelBuilder.Entity<Patient>()
                .Property(p => p.PatientName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Clinic>()
                .Property(c => c.ClinicSepcialization)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Booking>()
                .Property(b => b.DateToday)
                .IsRequired();

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
    }
}


