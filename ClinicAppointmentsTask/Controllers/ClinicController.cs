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
            if (clinics == null || !clinics.Any())
            {
                return NotFound(new { Message = "No clinics found", StatusCode = 404 });
            }

            return Ok(new { Data = clinics, Message = "Clinics retrieved successfully", StatusCode = 200 });
        }

        // GET: api/Clinic/{id}
        [HttpGet("{id}")]
        public IActionResult GetClinicById(int id)
        {
            var clinic = _clinicService.GetClinicById(id);
            if (clinic == null)
            {
                return NotFound(new { Message = "Clinic not found", StatusCode = 404 });
            }

            return Ok(new { Data = clinic, Message = "Clinic retrieved successfully", StatusCode = 200 });
        }

        // POST: api/Clinic
        [HttpPost]
        public IActionResult AddClinic(string CSepcia, int NumberOfSlots)
        {
            try
            {
                var clinic = new Clinic
                {
                    ClinicSepcialization = CSepcia,
                    NumberOfSlots = NumberOfSlots
                };

                _clinicService.AddClinic(clinic);
                return CreatedAtAction(nameof(GetClinicById), new { id = clinic.ClinicId }, new { Data = clinic, Message = "Clinic added successfully", StatusCode = 201 });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, StatusCode = 400 });
            }
        }

        // PUT: api/Clinic/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateClinic(int id, string CSepcia, int NumberOfSlots)
        {
            var clinic = _clinicService.GetClinicById(id);
            if (clinic == null)
            {
                return NotFound(new { Message = "Clinic not found", StatusCode = 404 });
            }

            try
            {
                clinic.ClinicSepcialization = CSepcia;
                clinic.NumberOfSlots = NumberOfSlots;

                _clinicService.UpdateClinic(clinic);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, StatusCode = 400 });
            }
        }

        // DELETE: api/Clinic/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteClinic(int id)
        {
            var clinic = _clinicService.GetClinicById(id);
            if (clinic == null)
            {
                return NotFound(new { Message = "Clinic not found", StatusCode = 404 });
            }

            _clinicService.DeleteClinic(id);
            return Ok(new { Message = "Clinic deleted successfully", StatusCode = 200 });
        }
    }
}
