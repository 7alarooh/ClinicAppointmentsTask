using ClinicAppointmentsTask.Models;
using ClinicAppointmentsTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentsTask.Controllers
{
    // Controller to manage patient-related endpoints in the application.
    // This serves as the Presentation Layer in a 3-tier system architecture.
    // Interacts with the PatientService to perform operations.

    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        // GET: api/Patient
        [HttpGet]
        public IActionResult GetAllPatients()
        {
            var patients = _service.GetAllPatients();
            return Ok(patients);
        }

        // GET: api/Patient/{id}
        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            var patient = _service.GetPatientById(id);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        // POST: api/Patient
        [HttpPost]
        public IActionResult AddPatient(string name, int age, string gender)
        {
            var patient = new Patient
            {
                PatientName = name,
                Age = age,
                Gender = Enum.TryParse<Gender>(gender, out var parsedGender) ? parsedGender : throw new ArgumentException("Invalid gender")
            };

            _service.AddPatient(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientId }, patient);
        }

        // PUT: api/Patient/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, string name, int age, string gender)
        {
            var patient = _service.GetPatientById(id);
            if (patient == null)
                return NotFound();

            patient.PatientName = name;
            patient.Age = age;
            patient.Gender = Enum.TryParse<Gender>(gender, out var parsedGender) ? parsedGender : throw new ArgumentException("Invalid gender");

            _service.UpdatePatient(patient);
            return NoContent();
        }

        // DELETE: api/Patient/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            _service.DeletePatient(id);
            return NoContent();
        }
    }
}
