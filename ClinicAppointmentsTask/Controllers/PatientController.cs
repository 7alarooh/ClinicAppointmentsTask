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
            if (patients == null || !patients.Any())
            {
                return NotFound(new { Message = "No patients found", StatusCode = 404 });
            }
            return Ok(new { Data = patients, Message = "Patients retrieved successfully", StatusCode = 200 });

        }

        // GET: api/Patient/{id}
        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            var patient = _service.GetPatientById(id);
            if (patient == null)
                return NotFound(new { Message = "Patient not found", StatusCode = 404 });

            return Ok(new { Data = patient, Message = "Patient retrieved successfully", StatusCode = 200 });

        }

        // POST: api/Patient
        [HttpPost]
        public IActionResult AddPatient(string name, int age, string gender)
        {
            try
            {
                var patient = new Patient
                {
                    PatientName = name,
                    Age = age,
                    Gender = Enum.TryParse<Gender>(gender, out var parsedGender) ? parsedGender : throw new ArgumentException("Invalid gender")
                };

                _service.AddPatient(patient);
                return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientId }, new { Data = patient, Message = "Patient created successfully", StatusCode = 201 });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message, StatusCode = 400 });
            }
        }

        // PUT: api/Patient/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, string name, int age, string gender)
        {
            var patient = _service.GetPatientById(id);
            if (patient == null)
                return NotFound(new { Message = "Patient not found", StatusCode = 404 });

            try
            {
                patient.PatientName = name;
                patient.Age = age;
                patient.Gender = Enum.TryParse<Gender>(gender, out var parsedGender) ? parsedGender : throw new ArgumentException("Invalid gender");

                _service.UpdatePatient(patient);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message, StatusCode = 400 });
            }
        }

        // DELETE: api/Patient/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _service.GetPatientById(id);
            if (patient == null)
                return NotFound(new { Message = "Patient not found", StatusCode = 404 });

            _service.DeletePatient(id);
            return Ok(new { Message = "Patient deleted successfully", StatusCode = 200 });
        }
    }
}
