// Controller to manage clinic-related endpoints in the application.
// This serves as the Presentation Layer in a 3-tier system architecture.
// Interacts with the ClinicService to perform operations.

using ClinicAppointmentsTask.Models;
using ClinicAppointmentsTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentsTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _service;

        public ClinicController(IClinicService service)
        {
            _service = service;
        }

        // GET: api/Clinic
        [HttpGet]
        public IActionResult GetAllClinics()
        {
            var clinics = _service.GetAllClinics();
            return Ok(clinics);
        }

        // GET: api/Clinic/{id}
        [HttpGet("{id}")]
        public IActionResult GetClinicById(int id)
        {
            var clinic = _service.GetClinicById(id);
            if (clinic == null)
                return NotFound();

            return Ok(clinic);
        }

        // POST: api/Clinic
        [HttpPost]
        public IActionResult AddClinic([FromBody] Clinic clinic)
        {
            _service.AddClinic(clinic);
            return CreatedAtAction(nameof(GetClinicById), new { id = clinic.ClinicId }, clinic);
        }

        // PUT: api/Clinic/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateClinic(int id, [FromBody] Clinic clinic)
        {
            if (id != clinic.ClinicId)
                return BadRequest();

            _service.UpdateClinic(clinic);
            return NoContent();
        }

        // DELETE: api/Clinic/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteClinic(int id)
        {
            _service.DeleteClinic(id);
            return NoContent();
        }
    }
}
