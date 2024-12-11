using ClinicAppointmentsTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentsTask.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all bookings
        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings.Include(b => b.Patient).Include(b => b.Clinic).ToList();
        }

        // Get a booking by composite key (PatientId, ClinicId, DateToday)
        public Booking? GetBookingById(int patientId, int clinicId, DateTime dateToday)
        {
            return _context.Bookings.FirstOrDefault(b => b.PatientId == patientId && b.ClinicId == clinicId && b.DateToday == dateToday);
        }

        // Add a new booking
        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        // Update an existing booking
        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        // Delete a booking by composite key (PatientId, ClinicId, DateToday)
        public void DeleteBooking(int patientId, int clinicId, DateTime dateToday)
        {
            var booking = GetBookingById(patientId, clinicId, dateToday);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
        // View bookings by Clinic ID
        public IEnumerable<Booking> ViewBookingsByClinicId(int clinicId)
        {
            return _context.Bookings.Include(b => b.Patient).Include(b => b.Clinic).Where(b => b.ClinicId == clinicId).ToList();
        }

        // View bookings by Clinic Specialization
        public IEnumerable<Booking> ViewBookingsByClinicSpecialization(string specialization)
        {
            return _context.Bookings.Include(b => b.Patient).Include(b => b.Clinic).Where(b => b.Clinic.ClinicSepcialization == specialization).ToList();
        }

        // View bookings by Patient ID
        public IEnumerable<Booking> ViewBookingsByPatientId(int patientId)
        {
            return _context.Bookings.Include(b => b.Patient).Include(b => b.Clinic).Where(b => b.PatientId == patientId).ToList();
        }

        // View appointments by Patient Name
        public IEnumerable<Booking> ViewAppointmentsByPatientName(string patientName)
        {
            return _context.Bookings.Include(b => b.Patient).Include(b => b.Clinic).Where(b => b.Patient.PatientName == patientName).ToList();
        }
    }
}
