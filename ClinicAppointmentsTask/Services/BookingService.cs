using ClinicAppointmentsTask.Models;
using ClinicAppointmentsTask.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentsTask.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ApplicationDbContext _context;

        public BookingService(IBookingRepository bookingRepository, ApplicationDbContext context)
        {
            _bookingRepository = bookingRepository;
            _context = context;
        }

        public async Task<string> BookAppointmentAsync(int patientId, int clinicId, DateTime date)
        {
            // Check if the clinic exists
            var clinic = await _context.Clinics.FindAsync(clinicId);
            if (clinic == null)
            {
                return "Clinic not found.";
            }

            // Check if the patient exists
            var patient = await _context.Patients.FindAsync(patientId);
            if (patient == null)
            {
                return "Patient not found.";
            }

            // Ensure the patient has not already booked in the same clinic for today or a future date
            var conflictingBooking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.PatientId == patientId && b.ClinicId == clinicId && b.DateToday.Date >= date.Date);

            if (conflictingBooking != null)
            {
                return "You already have an appointment in this clinic today or on a future date.";
            }

            // Get all bookings for the clinic on the given date
            var clinicBookings = await _context.Bookings
                .Where(b => b.ClinicId == clinicId && b.DateToday.Date == date.Date)
                .OrderBy(b => b.SlotNumber)
                .ToListAsync();

            // Calculate the maximum number of slots for the clinic
            clinic.NumberOfSlots = Math.Max(clinic.NumberOfSlots, clinicBookings.Count);
            await _context.SaveChangesAsync(); // Update the clinic table

            // Calculate available slots and assign time dynamically
            int maxSlots = clinic.NumberOfSlots; // Set maximum slots per day
            TimeSpan startTime = TimeSpan.FromHours(8); // Start time: 8:00 AM
            TimeSpan slotDuration = TimeSpan.FromMinutes(600 / maxSlots); // Split time dynamically between slots

            DateTime nextAvailableTime = date.Date.Add(startTime).Add(slotDuration * clinicBookings.Count);

            if (nextAvailableTime >= date.Date.AddHours(18)) // Ensure bookings do not exceed 6:00 PM
            {
                return "No available slots for this clinic on the selected date.";
            }

            // Create the booking
            var newBooking = new Booking
            {
                DateToday = nextAvailableTime,
                SlotNumber = clinicBookings.Count + 1,
                PatientId = patientId,
                ClinicId = clinicId,
                Patient = patient,
                Clinic = clinic
            };

            await _context.Bookings.AddAsync(newBooking);
            await _context.SaveChangesAsync();

            return $"Appointment successfully booked for {patient.PatientName} on {nextAvailableTime:yyyy-MM-dd HH:mm} at {clinic.ClinicSepcialization} clinic.";
        }
        public IEnumerable<Booking> ViewBookingsByClinicId(int clinicId)
        {
            return _bookingRepository.ViewBookingsByClinicId(clinicId);
        }

        public IEnumerable<Booking> ViewBookingsByClinicSpecialization(string specialization)
        {
            return _bookingRepository.ViewBookingsByClinicSpecialization(specialization);
        }

        public IEnumerable<Booking> ViewBookingsByPatientId(int patientId)
        {
            return _bookingRepository.ViewBookingsByPatientId(patientId);
        }

        public IEnumerable<Booking> ViewAppointmentsByPatientName(string patientName)
        {
            return _bookingRepository.ViewAppointmentsByPatientName(patientName);
        }
    }
}
