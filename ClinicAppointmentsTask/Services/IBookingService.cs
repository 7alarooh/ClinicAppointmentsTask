
namespace ClinicAppointmentsTask.Services
{
    public interface IBookingService
    {
        Task<string> BookAppointmentAsync(int patientId, int clinicId, DateTime date);
    }
}