using ClinicAppointmentsTask.Models;
using ClinicAppointmentsTask.Repositories;

namespace ClinicAppointmentsTask.Services
{
    // This service interacts with the PatientRepository and acts as the Business Logic Layer (BLL).
    // It provides higher-level operations on Patient data, abstracting away data access logic.

    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        // Retrieve all patients
        public IEnumerable<Patient> GetAllPatients()
        {
            return _repository.GetAllPatients();
        }

        // Retrieve a specific patient by ID
        public Patient? GetPatientById(int id)
        {
            return _repository.GetPatientById(id);
        }

        // Add a new patient
        public void AddPatient(Patient patient)
        {
            _repository.AddPatient(patient);
        }

        // Update patient information
        public void UpdatePatient(Patient patient)
        {
            _repository.UpdatePatient(patient);
        }

        // Delete a patient by ID
        public void DeletePatient(int id)
        {
            _repository.DeletePatient(id);
        }
    }
}
