using ClinicAppointmentsTask.Models;

namespace ClinicAppointmentsTask.Repositories
{
    public class PatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all patients
        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        // Get a patient by ID
        public Patient? GetPatientById(int id)
        {
            return _context.Patients.FirstOrDefault(p => p.PatientId == id);
        }

        // Add a new patient
        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        // Update an existing patient
        public void UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }

        // Delete a patient
        public void DeletePatient(int id)
        {
            var patient = GetPatientById(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }
    }
}
