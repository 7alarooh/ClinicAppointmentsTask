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
        private readonly IClinicService _clinicService;

        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        // GET: api/Clinic
        [HttpGet]
        public IActionResult GetAllClinics()
        {
            var clinics = _clinicService.GetAllClinics();
            return Ok(clinics);
        }

        // GET: api/Clinic/{id}
        [HttpGet("{id}")]
        public IActionResult GetClinicById(int id)
        {
            var clinic = _clinicService.GetClinicById(id);
            if (clinic == null)
                return NotFound();

            return Ok(clinic);
        }

        // POST: api/Clinic
        [HttpPost]
        public IActionResult AddClinic(string CSepcia, int NumberOfSlots)
        {
            var clinic = new Clinic
            {
                ClinicSepcialization = CSepcia,
                NumberOfSlots = NumberOfSlots
            };

            _clinicService.AddClinic(clinic);
            return CreatedAtAction(nameof(GetClinicById), new { id = clinic.ClinicId }, clinic);
        }

        // PUT: api/Clinic/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateClinic(int id, string CSepcia, int NumberOfSlots)
        {
            var clinic = _clinicService.GetClinicById(id);
            if (clinic == null)
                return NotFound();

            clinic.ClinicSepcialization = CSepcia;
            clinic.NumberOfSlots = NumberOfSlots;

            _clinicService.UpdateClinic(clinic);
            return NoContent();
        }

        // DELETE: api/Clinic/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteClinic(int id)
        {
            _clinicService.DeleteClinic(id);
            return NoContent();
        }
    }
}
