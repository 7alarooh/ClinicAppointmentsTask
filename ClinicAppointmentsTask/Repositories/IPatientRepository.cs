// Interface for the Patient Repository to define operations
using ClinicAppointmentsTask.Models;

namespace ClinicAppointmentsTask.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAllPatients();
        Patient? GetPatientById(int id);
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int id);
    }
}