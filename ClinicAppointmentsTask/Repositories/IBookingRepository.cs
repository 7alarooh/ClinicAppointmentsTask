using ClinicAppointmentsTask.Models;

namespace ClinicAppointmentsTask.Repositories
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAllBookings();
        Booking? GetBookingById(int patientId, int clinicId, DateTime dateToday);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int patientId, int clinicId, DateTime dateToday);
        IEnumerable<Booking> ViewBookingsByClinicId(int clinicId);
        IEnumerable<Booking> ViewBookingsByClinicSpecialization(string specialization);
        IEnumerable<Booking> ViewBookingsByPatientId(int patientId);
        IEnumerable<Booking> ViewAppointmentsByPatientName(string patientName);
    }
}