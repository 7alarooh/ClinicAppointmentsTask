using ClinicAppointmentsTask.Models;

namespace ClinicAppointmentsTask.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly ApplicationDbContext _context;

        public ClinicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all clinics
        public IEnumerable<Clinic> GetAllClinics()
        {
            return _context.Clinics.ToList();
        }

        // Get a clinic by ID
        public Clinic? GetClinicById(int id)
        {
            return _context.Clinics.FirstOrDefault(c => c.ClinicId == id);
        }

        // Add a new clinic
        public void AddClinic(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            _context.SaveChanges();
        }

        // Update an existing clinic
        public void UpdateClinic(Clinic clinic)
        {
            _context.Clinics.Update(clinic);
            _context.SaveChanges();
        }

        // Delete a clinic
        public void DeleteClinic(int id)
        {
            var clinic = GetClinicById(id);
            if (clinic != null)
            {
                _context.Clinics.Remove(clinic);
                _context.SaveChanges();
            }
        }
    }
}
