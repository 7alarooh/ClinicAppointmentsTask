// This service interacts with the ClinicRepository and acts as the Business Logic Layer (BLL).
// It provides higher-level operations on Clinic data, abstracting away data access logic.

using ClinicAppointmentsTask.Models;
using ClinicAppointmentsTask.Repositories;

namespace ClinicAppointmentsTask.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicService(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        // Retrieve all clinics
        public IEnumerable<Clinic> GetAllClinics()
        {
            return _clinicRepository.GetAllClinics();
        }

        // Retrieve a specific clinic by ID
        public Clinic? GetClinicById(int id)
        {
            return _clinicRepository.GetClinicById(id);
        }

        // Add a new clinic
        public void AddClinic(Clinic clinic)
        {
            _clinicRepository.AddClinic(clinic);
        }

        // Update clinic information
        public void UpdateClinic(Clinic clinic)
        {
            _clinicRepository.UpdateClinic(clinic);
        }

        // Delete a clinic by ID
        public void DeleteClinic(int id)
        {
            _clinicRepository.DeleteClinic(id);
        }
    }
}
