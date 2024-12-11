
using ClinicAppointmentsTask.Models;

namespace ClinicAppointmentsTask.Services
{
    // Interface for ClinicService to define higher-level operations
    public interface IClinicService
    {
        IEnumerable<Clinic> GetAllClinics();
        Clinic? GetClinicById(int id);
        void AddClinic(Clinic clinic);
        void UpdateClinic(Clinic clinic);
        void DeleteClinic(int id);
    }
}
