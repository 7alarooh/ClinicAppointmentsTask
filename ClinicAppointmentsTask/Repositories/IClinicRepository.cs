using ClinicAppointmentsTask.Models;

namespace ClinicAppointmentsTask.Repositories
{
    public interface IClinicRepository
    {
        IEnumerable<Clinic> GetAllClinics();
        Clinic? GetClinicById(int id);
        void AddClinic(Clinic clinic);
        void UpdateClinic(Clinic clinic);
        void DeleteClinic(int id);
    }
}