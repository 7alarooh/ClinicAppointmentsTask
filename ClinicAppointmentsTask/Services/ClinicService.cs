// This service interacts with the ClinicRepository and acts as the Business Logic Layer (BLL).
// It provides higher-level operations on Clinic data, abstracting away data access logic.

using ClinicAppointmentsTask.Models;
using ClinicAppointmentsTask.Repositories;

namespace ClinicAppointmentsTask.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IClinicRepository _repository;

        public ClinicService(IClinicRepository repository)
        {
            _repository = repository;
        }

        // Retrieve all clinics
        public IEnumerable<Clinic> GetAllClinics()
        {
            return _repository.GetAllClinics();
        }

        // Retrieve a specific clinic by ID
        public Clinic? GetClinicById(int id)
        {
            return _repository.GetClinicById(id);
        }

        // Add a new clinic
        public void AddClinic(Clinic clinic)
        {
            _repository.AddClinic(clinic);
        }

        // Update clinic information
        public void UpdateClinic(Clinic clinic)
        {
            _repository.UpdateClinic(clinic);
        }

        // Delete a clinic by ID
        public void DeleteClinic(int id)
        {
            _repository.DeleteClinic(id);
        }
    }
}
