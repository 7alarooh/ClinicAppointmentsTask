using ClinicAppointmentsTask.Models;

namespace ClinicAppointmentsTask.Services
{
    public interface IPatientService
    {  // Interface for PatientService to define higher-level operations
        IEnumerable<Patient> GetAllPatients();
        Patient? GetPatientById(int id);
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int id);
    }
}