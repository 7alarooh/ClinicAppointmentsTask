
using ClinicAppointmentsTask.Models;

namespace ClinicAppointmentsTask.Services
{
    public interface IBookingService
    {
        Task<string> BookAppointmentAsync(int patientId, int clinicId, DateTime date);
        IEnumerable<Booking> ViewBookingsByClinicId(int clinicId);
        IEnumerable<Booking> ViewBookingsByClinicSpecialization(string specialization);
        IEnumerable<Booking> ViewBookingsByPatientId(int patientId);
        IEnumerable<Booking> ViewAppointmentsByPatientName(string patientName);
    }
}